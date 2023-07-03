using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloTema
{
    public class RepositorioTemaEmSql : IRepositorioTema
    {
        private const string enderecoBanco =
             @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FestasInfantisDb;Integrated Security=True";

        private const string sqlInserir =
            @"INSERT INTO [TBTEMA]
                (
                    [NOME]
                   ,[VALOR]
                )
             VALUES
                (
                    @NOME
                   ,@VALOR
                )

            SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
           @"UPDATE [TBTEMA]
                SET 
                    [NOME] = @NOME
                   ,[VALOR] = @VALOR

	            WHERE 
		            [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBTEMA]
	            WHERE 
		            [ID] = @ID";

        private const string sqlSelecionarTodos =
          @"SELECT

                [ID]    TEMA_ID
	           ,[NOME]  TEMA_NOME
	           ,[VALOR] TEMA_VALOR

            FROM 
	            [TBTEMA]";

        private const string sqlSelecionarPorId =
            @"SELECT 

                [ID]    TEMA_ID
	           ,[NOME]  TEMA_NOME
	           ,[VALOR] TEMA_VALOR

            FROM 
	            [TBTEMA] 
            WHERE 
                [ID] = @ID";

        private const string sqlAdicionarItem =
            @"INSERT INTO [TBTema_TBItem]
                (
                    [Tema_Id]
                   ,[Item_Id])
            VALUES
                (
                    @Tema_Id
                   ,@Item_Id
                )";

        private const string sqlCarregarItens =
            @"SELECT 
	            I.ID            ITEM_ID, 
	            I.DESCRICAO     ITEM_DESCRICAO, 
	            I.VALOR         ITEM_VALOR
            FROM 
	            TBITEM I 
	
	            INNER JOIN TBTEMA_TBITEM TI
		
		            ON I.ID = TI.ITEM_ID
            WHERE 

	            TI.TEMA_ID = @TEMA_ID";

        private const string sqlRemoverItens =
            @"DELETE FROM TBTEMA_TBITEM 
                WHERE TEMA_ID = @TEMA_ID AND ITEM_ID = @ITEM_ID";


        private const string sqlSelecionarAlugueis =
         @"SELECT 
	             A.[ID]                      ALUGUEL_ID
                ,A.[PORCENTAGEMSINAL]        ALUGUEL_PORCENTAGEM_SINAL
                ,A.[PORCENTAGEMDESCONTO]     ALUGUEL_PORCENTAGEM_DESCONTO
                ,A.[DATAPAGAMENTO]           ALUGUEL_DATA_PAGAMENTO
                ,A.[PAGAMENTOCONCLUIDO]      ALUGUEL_PAGAMENTO_CONCLUIDO
	 							 
                ,A.[FESTA_DATA]              ALUGUEL_FESTA_DATA
                ,A.[FESTA_HORARIOINICIO]     ALUGUEL_FESTA_HORARIOINICIO
                ,A.[FESTA_HORARIOTERMINO]    ALUGUEL_FESTA_HORARIOTERMINO
	 							 
                ,A.[ENDERECO_ESTADO]         ALUGUEL_ENDERECO_ESTADO
                ,A.[ENDERECO_CIDADE]         ALUGUEL_ENDERECO_CIDADE
                ,A.[ENDERECO_BAIRRO]         ALUGUEL_ENDERECO_BAIRRO
                ,A.[ENDERECO_RUA]            ALUGUEL_ENDERECO_RUA
                ,A.[ENDERECO_NUMERO]         ALUGUEL_ENDERECO_NUMERO

                ,A.[CONFIGURACAO_PORCENTAGEMDESCONTO]       ALUGUEL_CONFIGURACAO_PORCENTAGEM_DESCONTO
                ,A.[CONFIGURACAO_PORCENTAGEMMAXIMA]         ALUGUEL_CONFIGURACAO_PORCENTAGEM_MAXIMA

	            ,A.[TEMA_ID]				 ALUGUEL_TEMA_ID
	            ,A.[CLIENTE_ID]				 ALUGUEL_CLIENTE_ID

                ,T.[ID]                      TEMA_ID
                ,T.[NOME]                    TEMA_NOME
                ,T.[VALOR]                    TEMA_VALOR

                ,C.[ID]                      CLIENTE_ID
                ,C.[NOME]                    CLIENTE_NOME
                ,C.[TELEFONE]                CLIENTE_TELEFONE

            FROM

		        [TBALUGUEL] AS A

		        INNER JOIN [TBCLIENTE] AS C

			        ON A.CLIENTE_ID = C.ID

		        INNER JOIN [TBTEMA] AS T

			        ON A.TEMA_ID = T.ID
            WHERE 
                T.[ID] = @TEMA_ID";

        public void Inserir(Tema novoTema, List<Item> itensAdicionados)
        {
            foreach (Item item in itensAdicionados)
            {
                novoTema.AdicionarItem(item);
            }

            novoTema.CalcularValor();

            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoInserir, novoTema);

            //executa o comando
            object id = comandoInserir.ExecuteScalar();

            novoTema.id = Convert.ToInt32(id);

            //encerra a conexão
            conexaoComBanco.Close();

            foreach (Item item in itensAdicionados)
            {
                AdicionarItem(item, novoTema);
            }
        }

        private void AdicionarItem(Item item, Tema tema)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlAdicionarItem;

            //adiciona os parâmetros no comando
            comandoInserir.Parameters.AddWithValue("TEMA_ID", tema.id);
            comandoInserir.Parameters.AddWithValue("ITEM_ID", item.id);

            //executa o comando
            comandoInserir.ExecuteNonQuery();

            //fecha conexão
            conexaoComBanco.Close();
        }

        public void Editar(int id, Tema tema, List<Item> itensMarcados, List<Item> itensDesmarcados)
        {
            foreach (Item itemParaAdicionar in itensMarcados)
            {
                if (tema.Contem(itemParaAdicionar))
                    continue;

                AdicionarItem(itemParaAdicionar, tema);
                tema.AdicionarItem(itemParaAdicionar);
            }

            foreach (Item itemParaRemover in itensDesmarcados)
            {
                if (tema.Contem(itemParaRemover))
                {
                    RemoverItem(itemParaRemover, tema);
                    tema.RemoverItem(itemParaRemover);
                }
            }

            tema.CalcularValor();

            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoEditar, tema);

            //executa o comando
            comandoEditar.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();                 
        }

        private void RemoverItem(Item item, Tema tema)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlRemoverItens;

            //adiciona os parâmetros no comando
            comandoInserir.Parameters.AddWithValue("TEMA_ID", tema.id);
            comandoInserir.Parameters.AddWithValue("ITEM_ID", item.id);

            //executa o comando
            comandoInserir.ExecuteNonQuery();

            //fecha conexão
            conexaoComBanco.Close();
        }

        public void Excluir(Tema temaSelecionado)
        {
            foreach (Item itemParaRemover in temaSelecionado.Itens)
            {
                RemoverItem(itemParaRemover, temaSelecionado);
            }

            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            //adiciona os parâmetros no comando
            comandoExcluir.Parameters.AddWithValue("ID", temaSelecionado.id);

            //executa o comando
            comandoExcluir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();           
        }

        public Tema SelecionarPorId(int id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarPorId = conexaoComBanco.CreateCommand();
            comandoSelecionarPorId.CommandText = sqlSelecionarPorId;

            //adicionar parametro
            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            //executa o comando
            SqlDataReader leitorTemas = comandoSelecionarPorId.ExecuteReader();

            Tema tema = null;

            if (leitorTemas.Read())
                tema = ConverterParaTema(leitorTemas);

            //encerra a conexão
            conexaoComBanco.Close();

            if (tema != null)
            {
                CarregarItens(tema);
                CarregarAlugueis(tema);
            }

            return tema;
        }

        private void CarregarItens(Tema tema)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarItens = conexaoComBanco.CreateCommand();
            comandoSelecionarItens.CommandText = sqlCarregarItens;

            comandoSelecionarItens.Parameters.AddWithValue("TEMA_ID", tema.id);

            //executa o comando
            SqlDataReader leitorItem = comandoSelecionarItens.ExecuteReader();

            while (leitorItem.Read())
            {
                Item item = ConverterParaItem(leitorItem);

                tema.AdicionarItem(item);
            }

            //encerra a conexão
            conexaoComBanco.Close();
        }

        private void CarregarAlugueis(Tema tema)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarAlugueisDoCliente = conexaoComBanco.CreateCommand();
            comandoSelecionarAlugueisDoCliente.CommandText = sqlSelecionarAlugueis;

            //configurar parâmetros
            comandoSelecionarAlugueisDoCliente.Parameters.AddWithValue("TEMA_ID", tema.id);

            //executa o comando
            SqlDataReader leitorAluguel = comandoSelecionarAlugueisDoCliente.ExecuteReader();

            while (leitorAluguel.Read())
            {
                Aluguel aluguel = ConverterParaAluguel(leitorAluguel, tema);

                tema.RegistrarAluguel(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();
        }

        private Aluguel ConverterParaAluguel(SqlDataReader leitorAlugueis, Tema tema)
        {
            int id = Convert.ToInt32(leitorAlugueis["ALUGUEL_ID"]);
            decimal porcentagemSinal = Convert.ToDecimal(leitorAlugueis["ALUGUEL_PORCENTAGEM_SINAL"]);
            decimal porcentagemDesconto = Convert.ToDecimal(leitorAlugueis["ALUGUEL_PORCENTAGEM_DESCONTO"]);

            bool pagamentoConcluido = false;
            DateTime dataPagamento = DateTime.MinValue;

            if (leitorAlugueis["ALUGUEL_DATA_PAGAMENTO"] != DBNull.Value)
            {
                dataPagamento = Convert.ToDateTime(leitorAlugueis["ALUGUEL_DATA_PAGAMENTO"]);
                pagamentoConcluido = Convert.ToBoolean(leitorAlugueis["ALUGUEL_PAGAMENTO_CONCLUIDO"]);
            }

            ConfiguracaoDesconto configuracaoDesconto = ConverterParaConfiguracaoDesconto(leitorAlugueis);

            Festa festa = ConverterParaFesta(leitorAlugueis);            

            Cliente cliente = ConverterParaCliente(leitorAlugueis);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemSinal, porcentagemDesconto);

            aluguel.id = id;
            aluguel.PagamentoConcluido = pagamentoConcluido;
            aluguel.DataPagamento = dataPagamento;
            aluguel.ConfiguracaoDesconto = configuracaoDesconto;

            return aluguel;
        }

        private static ConfiguracaoDesconto ConverterParaConfiguracaoDesconto(SqlDataReader leitorAlugueis)
        {
            decimal configuracaoPorcentagemDesconto = Convert.ToDecimal(leitorAlugueis["ALUGUEL_CONFIGURACAO_PORCENTAGEM_DESCONTO"]);
            decimal configuracaoPorcentagemMaxima = Convert.ToDecimal(leitorAlugueis["ALUGUEL_CONFIGURACAO_PORCENTAGEM_MAXIMA"]);

            ConfiguracaoDesconto configuracaoDesconto = new ConfiguracaoDesconto(configuracaoPorcentagemDesconto, configuracaoPorcentagemMaxima);

            return configuracaoDesconto;
        }

        private static Festa ConverterParaFesta(SqlDataReader leitorAlugueis)
        {
            DateTime dataFesta = Convert.ToDateTime(leitorAlugueis["ALUGUEL_FESTA_DATA"]);
            TimeSpan horarioInicio = TimeSpan.FromTicks(Convert.ToInt64(leitorAlugueis["ALUGUEL_FESTA_HORARIOINICIO"]));
            TimeSpan horarioTermino = TimeSpan.FromTicks(Convert.ToInt64(leitorAlugueis["ALUGUEL_FESTA_HORARIOTERMINO"]));

            Endereco endereco = ConverterParaEndereco(leitorAlugueis);

            Festa festa = new Festa(endereco, dataFesta, horarioInicio, horarioTermino);
            return festa;
        }        

        private static Cliente ConverterParaCliente(SqlDataReader leitorAlugueis)
        {
            int idCliente = Convert.ToInt32(leitorAlugueis["CLIENTE_ID"]);
            string nomeCliente = Convert.ToString(leitorAlugueis["CLIENTE_NOME"]);
            string telefoneCliente = Convert.ToString(leitorAlugueis["CLIENTE_TELEFONE"]);

            Cliente cliente = new Cliente(idCliente, nomeCliente, telefoneCliente);
            return cliente;
        }

        private static Endereco ConverterParaEndereco(SqlDataReader leitorAlugueis)
        {
            string estado = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_ESTADO"]);
            string cidade = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_CIDADE"]);
            string bairro = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_BAIRRO"]);
            string rua = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_RUA"]);
            string numero = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_NUMERO"]);

            Endereco endereco = new Endereco(rua, bairro, cidade, estado, numero);
            return endereco;
        }

        private Item ConverterParaItem(SqlDataReader leitorItem)
        {
            int id = Convert.ToInt32(leitorItem["ITEM_ID"]);
            string descricao = Convert.ToString(leitorItem["ITEM_DESCRICAO"]);
            decimal valor = Convert.ToDecimal(leitorItem["ITEM_VALOR"]);

            return new Item(id, descricao, valor);
        }

        public List<Tema> SelecionarTodos(bool carregarItens = false, bool carregarAlugueis = false)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            //executa o comando
            SqlDataReader leitorTemas = comandoSelecionarTodos.ExecuteReader();

            List<Tema> temas = new List<Tema>();

            while (leitorTemas.Read())
            {
                Tema tema = ConverterParaTema(leitorTemas);

                if (carregarItens)                
                    CarregarItens(tema);
                
                if (carregarAlugueis)
                    CarregarAlugueis(tema);

                temas.Add(tema);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return temas;
        }

        private static Tema ConverterParaTema(SqlDataReader leitorTemas)
        {
            int id = Convert.ToInt32(leitorTemas["TEMA_ID"]);

            string nome = Convert.ToString(leitorTemas["TEMA_NOME"]);

            decimal valor = Convert.ToDecimal(leitorTemas["TEMA_VALOR"]);

            return new Tema(id, nome, valor);
        }

        private void ConfigurarParametros(SqlCommand comandoInserir, Tema novoTema)
        {
            comandoInserir.Parameters.AddWithValue("ID", novoTema.id);

            comandoInserir.Parameters.AddWithValue("NOME", novoTema.nome);

            comandoInserir.Parameters.AddWithValue("VALOR", novoTema.Valor);
        }
    }
}
