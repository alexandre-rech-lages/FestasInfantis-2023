using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloAluguel
{
    public class RepositorioAluguelEmSql : IRepositorioAluguel
    {
        private const string enderecoBanco =
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FestasInfantisDb;Integrated Security=True";

        private const string sqlInserir =
            @"INSERT INTO [TBALUGUEL]
                   (
				        [PORCENTAGEMSINAL]
			           ,[PORCENTAGEMDESCONTO]
			           ,[DATAPAGAMENTO]
			           ,[PAGAMENTOCONCLUIDO]
			           ,[FESTA_DATA]
			           ,[FESTA_HORARIOINICIO]
			           ,[FESTA_HORARIOTERMINO]
			           ,[ENDERECO_ESTADO]
			           ,[ENDERECO_CIDADE]
			           ,[ENDERECO_BAIRRO]
			           ,[ENDERECO_RUA]
			           ,[ENDERECO_NUMERO]
			           ,[TEMA_ID]
			           ,[CLIENTE_ID]
		           )
             VALUES
                   (
			            @PORCENTAGEMSINAL
			           ,@PORCENTAGEMDESCONTO
			           ,@DATAPAGAMENTO
			           ,@PAGAMENTOCONCLUIDO
			           ,@FESTA_DATA
			           ,@FESTA_HORARIOINICIO
			           ,@FESTA_HORARIOTERMINO
			           ,@ENDERECO_ESTADO
			           ,@ENDERECO_CIDADE
			           ,@ENDERECO_BAIRRO
			           ,@ENDERECO_RUA
			           ,@ENDERECO_NUMERO
			           ,@TEMA_ID
			           ,@CLIENTE_ID
			        );
            
            SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBALUGUEL]

                   SET 

                       [PORCENTAGEMSINAL] = @PORCENTAGEMSINAL
                      ,[PORCENTAGEMDESCONTO] = @PORCENTAGEMDESCONTO
                      ,[DATAPAGAMENTO] = @DATAPAGAMENTO
                      ,[PAGAMENTOCONCLUIDO] = @PAGAMENTOCONCLUIDO
                      ,[FESTA_DATA] = @FESTA_DATA
                      ,[FESTA_HORARIOINICIO] = @FESTA_HORARIOINICIO
                      ,[FESTA_HORARIOTERMINO] = @FESTA_HORARIOTERMINO
                      ,[ENDERECO_ESTADO] = @ENDERECO_ESTADO
                      ,[ENDERECO_CIDADE] = @ENDERECO_CIDADE
                      ,[ENDERECO_BAIRRO] = @ENDERECO_BAIRRO
                      ,[ENDERECO_RUA] = @ENDERECO_RUA
                      ,[ENDERECO_NUMERO] = @ENDERECO_NUMERO
                      ,[TEMA_ID] = @TEMA_ID
                      ,[CLIENTE_ID] = @CLIENTE_ID

                 WHERE 
	
	                [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBALUGUEL]

                 WHERE 
	
	                [ID] = @ID";
        
        private const string sqlSelecionarTodos =
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

			        ON A.TEMA_ID = T.ID";

        private const string sqlSelecionarPorId =
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
                ,T.[VALOR]                   TEMA_VALOR

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

				A.[ID] = @ID";

        private const string sqlSelecionarConcluidos =
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
                ,T.[VALOR]                   TEMA_VALOR

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

				A.[PAGAMENTOCONCLUIDO] = 1";

        private const string sqlSelecionarPendentes =
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
                ,T.[VALOR]                   TEMA_VALOR

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

				A.[PAGAMENTOCONCLUIDO] = 0";


        public void Inserir(Aluguel novoAluguel)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoInserir, novoAluguel);

            //executa o comando
            object id = comandoInserir.ExecuteScalar();

            novoAluguel.id = Convert.ToInt32(id);

            //encerra a conexão
            conexaoComBanco.Close();
        }
        
        public void Editar(int id, Aluguel aluguel)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoEditar, aluguel);

            comandoEditar.Parameters.AddWithValue("ID", id);

            //executa o comando
            comandoEditar.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }
       
        public void Excluir(Aluguel aluguelSelecionado)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            //adiciona os parâmetros no comando
            comandoExcluir.Parameters.AddWithValue("ID", aluguelSelecionado.id);

            //executa o comando
            comandoExcluir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }

        public List<Aluguel> SelecionarTodos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            //executa o comando
            SqlDataReader leitorAlugueis = comandoSelecionarTodos.ExecuteReader();

            List<Aluguel> alugeis = new List<Aluguel>();

            while (leitorAlugueis.Read())
            {
                Aluguel aluguel = ConverterParaAluguel(leitorAlugueis);

                alugeis.Add(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return alugeis;
        }                
       
        public List<Aluguel> SelecionarConcluidos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarConcluidos;

            //executa o comando
            SqlDataReader leitorAlugueis = comandoSelecionarTodos.ExecuteReader();

            List<Aluguel> alugeis = new List<Aluguel>();

            while (leitorAlugueis.Read())
            {
                Aluguel aluguel = ConverterParaAluguel(leitorAlugueis);

                alugeis.Add(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return alugeis;
        }

        public List<Aluguel> SelecionarPendentes()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarPendentes;

            //executa o comando
            SqlDataReader leitorAlugueis = comandoSelecionarTodos.ExecuteReader();

            List<Aluguel> alugeis = new List<Aluguel>();

            while (leitorAlugueis.Read())
            {
                Aluguel aluguel = ConverterParaAluguel(leitorAlugueis);

                alugeis.Add(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return alugeis;
        }

        public Aluguel SelecionarPorId(int id)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarPorId = conexaoComBanco.CreateCommand();
            comandoSelecionarPorId.CommandText = sqlSelecionarPorId;

            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            //executa o comando
            SqlDataReader leitorAlugueis = comandoSelecionarPorId.ExecuteReader();

            Aluguel aluguel = null;

            if (leitorAlugueis.Read())
            {
                aluguel = ConverterParaAluguel(leitorAlugueis);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return aluguel;
        }

        public bool VerificarAlugueisAbertosCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool VerificarTemasIndisponiveis(Tema tema)
        {
            return true; //throw new NotImplementedException();
        }


        private void ConfigurarParametros(SqlCommand comando, Aluguel aluguel)
        {
            comando.Parameters.AddWithValue("PORCENTAGEMSINAL", aluguel.PorcentagemSinal);
            comando.Parameters.AddWithValue("PORCENTAGEMDESCONTO", aluguel.PorcentagemDesconto);

            if (aluguel.DataPagamento == null)
                comando.Parameters.AddWithValue("DATAPAGAMENTO", DBNull.Value);
            else
                comando.Parameters.AddWithValue("DATAPAGAMENTO", aluguel.DataPagamento);

            comando.Parameters.AddWithValue("PAGAMENTOCONCLUIDO", aluguel.PagamentoConcluido);
            comando.Parameters.AddWithValue("FESTA_DATA", aluguel.Festa.Data);
            comando.Parameters.AddWithValue("FESTA_HORARIOINICIO", aluguel.Festa.HorarioInicio.Ticks);
            comando.Parameters.AddWithValue("FESTA_HORARIOTERMINO", aluguel.Festa.HorarioTermino.Ticks);
            comando.Parameters.AddWithValue("ENDERECO_ESTADO", aluguel.Festa.Endereco.Estado);
            comando.Parameters.AddWithValue("ENDERECO_CIDADE", aluguel.Festa.Endereco.Cidade);
            comando.Parameters.AddWithValue("ENDERECO_BAIRRO", aluguel.Festa.Endereco.Bairro);
            comando.Parameters.AddWithValue("ENDERECO_RUA", aluguel.Festa.Endereco.Rua);
            comando.Parameters.AddWithValue("ENDERECO_NUMERO", aluguel.Festa.Endereco.Numero);

            comando.Parameters.AddWithValue("TEMA_ID", aluguel.Tema.id);
            comando.Parameters.AddWithValue("CLIENTE_ID", aluguel.Cliente.id);

        }


        private Aluguel ConverterParaAluguel(SqlDataReader leitorAlugueis)
        {
            int id = Convert.ToInt32(leitorAlugueis["ALUGUEL_ID"]);
            decimal porcentagemSinal = Convert.ToDecimal(leitorAlugueis["ALUGUEL_PORCENTAGEM_SINAL"]);
            decimal porcentagemDesconto = Convert.ToDecimal(leitorAlugueis["ALUGUEL_PORCENTAGEM_DESCONTO"]);

            DateTime dataPagamento;
            if (leitorAlugueis["ALUGUEL_DATA_PAGAMENTO"] != DBNull.Value)
                dataPagamento = Convert.ToDateTime(leitorAlugueis["ALUGUEL_DATA_PAGAMENTO"]);

            Festa festa = ConverterParaFesta(leitorAlugueis);

            Tema tema = ConverterParaTema(leitorAlugueis);

            Cliente cliente = ConverterParaCliente(leitorAlugueis);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemSinal, porcentagemDesconto);

            aluguel.id = id;

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

    }
}
