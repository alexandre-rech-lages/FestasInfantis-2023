using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Sql.Compartilhado;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloAluguel
{
    public class RepositorioAluguelEmSql : RepositorioEmSqlBase<Aluguel, MapeadorAluguel>, IRepositorioAluguel
    {       
        protected override string sqlInserir =>
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
                       ,[CONFIGURACAO_PORCENTAGEMDESCONTO]
                       ,[CONFIGURACAO_PORCENTAGEMMAXIMA]
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
                       ,@CONFIGURACAO_PORCENTAGEMDESCONTO
                       ,@CONFIGURACAO_PORCENTAGEMMAXIMA
			           ,@TEMA_ID
			           ,@CLIENTE_ID
			        );
            
            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
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
                      ,[CONFIGURACAO_PORCENTAGEMDESCONTO] = @CONFIGURACAO_PORCENTAGEMDESCONTO
                      ,[CONFIGURACAO_PORCENTAGEMMAXIMA] = @CONFIGURACAO_PORCENTAGEMMAXIMA

                 WHERE 
	
	                [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBALUGUEL]

                 WHERE 
	
	                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
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
                ,T.[VALOR]                   TEMA_VALOR

                ,C.[ID]                      CLIENTE_ID
                ,C.[NOME]                    CLIENTE_NOME
                ,C.[TELEFONE]                CLIENTE_TELEFONE

            FROM

		        [TBALUGUEL] AS A

		        INNER JOIN [TBCLIENTE] AS C

			        ON A.CLIENTE_ID = C.ID

		        INNER JOIN [TBTEMA] AS T

			        ON A.TEMA_ID = T.ID";

        protected override string sqlSelecionarPorId =>
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

                ,A.[CONFIGURACAO_PORCENTAGEMDESCONTO]       ALUGUEL_CONFIGURACAO_PORCENTAGEM_DESCONTO
                ,A.[CONFIGURACAO_PORCENTAGEMMAXIMA]         ALUGUEL_CONFIGURACAO_PORCENTAGEM_MAXIMA

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

                ,A.[CONFIGURACAO_PORCENTAGEMDESCONTO]       ALUGUEL_CONFIGURACAO_PORCENTAGEM_DESCONTO
                ,A.[CONFIGURACAO_PORCENTAGEMMAXIMA]         ALUGUEL_CONFIGURACAO_PORCENTAGEM_MAXIMA

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

            MapeadorAluguel mapeador = new MapeadorAluguel();

            while (leitorAlugueis.Read())
            {
                Aluguel aluguel = mapeador.ConverterRegistro(leitorAlugueis);

                alugeis.Add(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return alugeis;
        }

        public List<Aluguel> SelecionarPendentes()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(base.enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarPendentes;

            //executa o comando
            SqlDataReader leitorAlugueis = comandoSelecionarTodos.ExecuteReader();

            List<Aluguel> alugeis = new List<Aluguel>();

            MapeadorAluguel mapeador = new MapeadorAluguel();

            while (leitorAlugueis.Read())
            {
                Aluguel aluguel = mapeador.ConverterRegistro(leitorAlugueis);

                alugeis.Add(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return alugeis;
        }

    }
}
