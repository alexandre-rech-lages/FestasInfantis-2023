using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Sql.Compartilhado;
using FestasInfantis.Infra.Dados.Sql.ModuloAluguel;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloCliente
{
    public class RepositorioClienteEmSql : RepositorioEmSqlBase<Cliente, MapeadorCliente>, IRepositorioCliente
    {        
        protected override string sqlInserir =>
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

        protected override string sqlEditar =>
            @"UPDATE [TBCLIENTE] 
	            SET 
		            [NOME] = @NOME,
		            [TELEFONE] = @TELEFONE
	            WHERE 
		            [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]
	            WHERE 
		            [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 

	            [ID]        CLIENTE_ID 
	           ,[NOME]      CLIENTE_NOME
	           ,[TELEFONE]  CLIENTE_TELEFONE

            FROM 
	            [TBCLIENTE]";

        protected override string sqlSelecionarPorId =>
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
                C.[ID] = @CLIENTE_ID";
           

        public override Cliente SelecionarPorId(int id)
        {
            Cliente cliente = base.SelecionarPorId(id);            

            if (cliente != null)
                CarregarAlugueis(cliente);

            return cliente;
        }

        public List<Cliente> SelecionarTodos(bool carregarAlugueis = false)
        {
            List<Cliente> clientes = base.SelecionarTodos();

            foreach (Cliente cliente in clientes)
            {
                if (carregarAlugueis)
                    CarregarAlugueis(cliente);             
            }

            return clientes;
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

            MapeadorAluguel mapeador = new MapeadorAluguel();

            while (leitorAluguel.Read())
            {
                Aluguel aluguel = mapeador.ConverterRegistro(leitorAluguel);

                cliente.RegistrarAluguel(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();
        }       
    }
}
