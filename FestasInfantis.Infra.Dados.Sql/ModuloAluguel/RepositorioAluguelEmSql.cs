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

               ,T.[ID]                      TEMA_ID
               ,T.[NOME]                    TEMA_NOME

               ,C.[ID]                      CLIENTE_ID
               ,C.[NOME]                    CLIENTE_NOME
               ,C.[TELEFONE]                CLIENTE_TELEFONE

              FROM
                [DBO].[TBALUGUEL] AS A INNER JOIN [DBO].[TBTEMA] AS T
              ON
                A.TEMA_ID = T.ID INNER JOIN [DBO].[TBCLIENTE] AS C
              ON
                A.CLIENTE_ID = C.ID";

        private Aluguel ConverterParaAluguel(SqlDataReader leitorAlugueis)
        {
            int id = Convert.ToInt32(leitorAlugueis["ALUGUEL_ID"]);
            decimal porcentagemSinal = Convert.ToDecimal(leitorAlugueis["ALUGUEL_PORCENTAGEM_SINAL"]);
            decimal porcentagemDesconto = Convert.ToDecimal(leitorAlugueis["ALUGUEL_PORCENTAGEM_DESCONTO"]);

            DateTime dataPagamento;
            if (leitorAlugueis["ALUGUEL_DATA_PAGAMENTO"] != DBNull.Value)  
                dataPagamento = Convert.ToDateTime(leitorAlugueis["ALUGUEL_DATA_PAGAMENTO"]);

            DateTime dataFesta = Convert.ToDateTime(leitorAlugueis["ALUGUEL_FESTA_DATA"]);
            TimeSpan horarioInicio = TimeSpan.FromTicks( Convert.ToInt64(leitorAlugueis["ALUGUEL_FESTA_HORARIOINICIO"]));
            TimeSpan horarioTermino = TimeSpan.FromTicks(Convert.ToInt64(leitorAlugueis["ALUGUEL_FESTA_HORARIOTERMINO"]));
            
            string estado = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_ESTADO"]);
            string cidade = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_CIDADE"]);
            string bairro = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_BAIRRO"]);
            string rua = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_RUA"]);
            string numero = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_NUMERO"]);           

            int idTema = Convert.ToInt32(leitorAlugueis["TEMA_ID"]);
            string nomeTema = Convert.ToString(leitorAlugueis["TEMA_NOME"]);

            int idCliente = Convert.ToInt32(leitorAlugueis["CLIENTE_ID"]);
            string nomeCliente = Convert.ToString(leitorAlugueis["CLIENTE_NOME"]);
            string telefoneCliente = Convert.ToString(leitorAlugueis["CLIENTE_TELEFONE"]);

            Endereco endereco = new Endereco(rua, bairro, cidade, estado, numero);

            Festa festa = new Festa(endereco, dataFesta, horarioInicio, horarioTermino);

            Tema tema = new Tema(idTema, nomeTema);

            Cliente cliente = new Cliente(idCliente, nomeCliente, telefoneCliente);

            return new Aluguel(cliente, festa, tema, porcentagemSinal, porcentagemDesconto);
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

            while( leitorAlugueis.Read())
            {
                Aluguel aluguel = ConverterParaAluguel(leitorAlugueis);

                alugeis.Add(aluguel);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return alugeis;
        }

       

        public void Inserir(Aluguel novoAluguel)
        {
            throw new NotImplementedException();
        }

        public void Editar(int id, Aluguel aluguel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Aluguel aluguelSelecionado)
        {
            throw new NotImplementedException();
        }

        public List<Aluguel> SelecionarConcluidas()
        {
            throw new NotImplementedException();
        }

        public List<Aluguel> SelecionarPendentes()
        {
            throw new NotImplementedException();
        }

        public Aluguel SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

       

        public bool VerificarAlugueisAbertosCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool VerificarTemasIndisponiveis(Tema tema)
        {
            throw new NotImplementedException();
        }
    }
}
