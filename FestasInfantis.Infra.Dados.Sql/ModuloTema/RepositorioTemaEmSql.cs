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
                )
             VALUES
                (
                    @NOME
                )

            SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
           @"UPDATE [TBTEMA]
                SET 
                    [NOME] = @NOME

	            WHERE 
		            [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBTEMA]
	            WHERE 
		            [ID] = @ID";

        private const string sqlSelecionarTodos =
          @"SELECT
                [ID] TEMA_ID
	           ,[NOME] TEMA_NOME
            FROM 
	            [TBTEMA]";

        private const string sqlSelecionarPorId =
            @"SELECT 
                [ID] TEMA_ID
	           ,[NOME] TEMA_NOME
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

        public void Inserir(Tema novoTema, List<Item> itensAdicionados)
        {
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

        public void Editar(int id, Tema tema)
        {
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

        public void Excluir(Tema temaSelecionado)
        {
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
                CarregarItens(tema);

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

            List<Item> itens = new List<Item>();

            while (leitorItem.Read())
            {
                Item item = ConverterParaItem(leitorItem);

                tema.AdicionarItem(item);
            }

            //encerra a conexão
            conexaoComBanco.Close();
        }

        private Item ConverterParaItem(SqlDataReader leitorItem)
        {
            int id = Convert.ToInt32(leitorItem["ITEM_ID"]);
            string descricao = Convert.ToString(leitorItem["ITEM_DESCRICAO"]);
            decimal valor = Convert.ToDecimal(leitorItem["ITEM_VALOR"]);

            return new Item(id, descricao, valor);
        }

        public List<Tema> SelecionarTodos()
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

            return new Tema(id, nome);
        }

        private void ConfigurarParametros(SqlCommand comandoInserir, Tema novoTema)
        {
            comandoInserir.Parameters.AddWithValue("ID", novoTema.id);

            comandoInserir.Parameters.AddWithValue("NOME", novoTema.nome);
        }
    }
}
