using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloCliente
{
    public class RepositorioClienteEmSql : IRepositorioCliente
    {
        private const string enderecoBanco = 
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FestasInfantisDb;Integrated Security=True";

        private const string sqlInserir =
            @"INSERT INTO [TBCLIENTE] 
	            (
		            [NOME], 
		            [TELEFONE]
	            )
	            VALUES 
	            (
		            @NOME, 
		            @TELEFONE
	            );                 

            SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBCLIENTE] 
	            SET 
		            [NOME] = @NOME,
		            [TELEFONE] = @TELEFONE
	            WHERE 
		            [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBCLIENTE]
	            WHERE 
		            [ID] = @ID";

        private const string sqlSelecionarTodos =
            @"SELECT 

	            [ID]        CLIENTE_ID 
	           ,[NOME]      CLIENTE_NOME
	           ,[TELEFONE]  CLIENTE_TELEFONE

            FROM 
	            [TBCLIENTE]";

        private const string sqlSelecionarPorId =
            @"SELECT 

	            [ID]        CLIENTE_ID 
	           ,[NOME]      CLIENTE_NOME
	           ,[TELEFONE]  CLIENTE_TELEFONE

            FROM 
	            [TBCLIENTE] 
            WHERE 
                [ID] = @ID";

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
                C.[ID] = @CLIENTE_ID";

        public void Inserir(Cliente novoCliente)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoInserir, novoCliente);

            //executa o comando
            object id = comandoInserir.ExecuteScalar();

            novoCliente.id = Convert.ToInt32(id);

            //encerra a conexão
            conexaoComBanco.Close();
        }      

        public void Editar(int id, Cliente cliente)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoEditar, cliente);

            //executa o comando
            comandoEditar.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }

        public void Excluir(Cliente clienteSelecionado)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            //adiciona os parâmetros no comando
            comandoExcluir.Parameters.AddWithValue("ID", clienteSelecionado.id);

            //executa o comando
            comandoExcluir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }       

        public Cliente SelecionarPorId(int id)
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
            SqlDataReader leitorClientes = comandoSelecionarPorId.ExecuteReader();

            Cliente cliente = null;

            if (leitorClientes.Read())            
                cliente = ConverterParaCliente(leitorClientes);

            if (cliente != null)
                CarregarAlugueis(cliente);

            //encerra a conexão
            conexaoComBanco.Close();

            return cliente;
        }

        private void CarregarAlugueis(Cliente cliente)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarAlugueisDoCliente = conexaoComBanco.CreateCommand();
            comandoSelecionarAlugueisDoCliente.CommandText = sqlSelecionarAlugueis;

            //configurar parâmetros
            comandoSelecionarAlugueisDoCliente.Parameters.AddWithValue("CLIENTE_ID", cliente.id);

            //executa o comando
            SqlDataReader leitorAluguel = comandoSelecionarAlugueisDoCliente.ExecuteReader();

            while (leitorAluguel.Read())
            {
                Aluguel aluguel = ConverterParaAluguel(leitorAluguel, cliente);

                cliente.RegistrarAluguel(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();
        }

        private Aluguel ConverterParaAluguel(SqlDataReader leitorAlugueis, Cliente cliente)
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

            Festa festa = ConverterParaFesta(leitorAlugueis);

            Tema tema = ConverterParaTema(leitorAlugueis);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemSinal, porcentagemDesconto);

            aluguel.id = id;
            aluguel.PagamentoConcluido = pagamentoConcluido;
            aluguel.DataPagamento = dataPagamento;


            return aluguel;
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

        private static Tema ConverterParaTema(SqlDataReader leitorAlugueis)
        {
            int id = Convert.ToInt32(leitorAlugueis["TEMA_ID"]);
            string nome = Convert.ToString(leitorAlugueis["TEMA_NOME"]);
            decimal valor = Convert.ToDecimal(leitorAlugueis["TEMA_VALOR"]);

            Tema tema = new Tema(id, nome, valor);

            return tema;
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


        public List<Cliente> SelecionarTodos(bool carregarAlugueis = false)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;            

            //executa o comando
            SqlDataReader leitorClientes = comandoSelecionarTodos.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (leitorClientes.Read())
            {
                Cliente cliente = ConverterParaCliente(leitorClientes);

                if (carregarAlugueis)
                    CarregarAlugueis(cliente);

                clientes.Add(cliente);  
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return clientes;
        }      

        private void ConfigurarParametros(SqlCommand comandoInserir, Cliente novoCliente)
        {
            comandoInserir.Parameters.AddWithValue("ID", novoCliente.id);

            comandoInserir.Parameters.AddWithValue("NOME", novoCliente.nome);

            comandoInserir.Parameters.AddWithValue("TELEFONE", novoCliente.telefone);
        }
    }
}
