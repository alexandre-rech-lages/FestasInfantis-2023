using FestasInfantis.Dominio.ModuloItem;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloItem
{
    public class RepositorioItemEmSql : IRepositorioItem
    {
        private const string enderecoBanco =
             @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FestasInfantisDb;Integrated Security=True";

        private const string sqlInserir =
         @"INSERT INTO [TBITEM]
                (
                    [DESCRICAO]
                   ,[VALOR]
                )
             VALUES
                (
                    @DESCRICAO
                   ,@VALOR
                )

            SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
          @"UPDATE [TBITEM]
                SET 
                    [DESCRICAO] = @DESCRICAO
                   ,[VALOR] = @VALOR

	            WHERE 
		            [ID] = @ID";

        private const string sqlExcluir =
          @"DELETE FROM [TBITEM]
	            WHERE 
		            [ID] = @ID";

        private const string sqlSelecionarPorId =
           @"SELECT 
                [ID]            ITEM_ID
	           ,[DESCRICAO]     ITEM_DESCRICAO
	           ,[VALOR]         ITEM_VALOR

            FROM 
	            [TBITEM] 
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarTodos =
          @"SELECT
                [ID]            ITEM_ID
	           ,[DESCRICAO]     ITEM_DESCRICAO
	           ,[VALOR]         ITEM_VALOR
            FROM 
	            [TBITEM]";

        public void Inserir(Item novoItem)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoInserir, novoItem);

            //executa o comando
            object id = comandoInserir.ExecuteScalar();

            novoItem.id = Convert.ToInt32(id);

            //encerra a conexão
            conexaoComBanco.Close();
        }    

        public void Editar(int id, Item item)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoEditar = conexaoComBanco.CreateCommand();
            comandoEditar.CommandText = sqlEditar;

            //adiciona os parâmetros no comando
            ConfigurarParametros(comandoEditar, item);

            //executa o comando
            comandoEditar.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }

        public void Excluir(Item itemSelecionado)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            //adiciona os parâmetros no comando
            comandoExcluir.Parameters.AddWithValue("ID", itemSelecionado.id);

            //executa o comando
            comandoExcluir.ExecuteNonQuery();

            //encerra a conexão
            conexaoComBanco.Close();
        }        

        public Item SelecionarPorId(int id)
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
            SqlDataReader leitorItems = comandoSelecionarPorId.ExecuteReader();

            Item item = null;

            if (leitorItems.Read())
                item = ConverterParaItem(leitorItems);

            //encerra a conexão
            conexaoComBanco.Close();

            return item;
        }

        private Item ConverterParaItem(SqlDataReader leitorItens)
        {
            int id = Convert.ToInt32(leitorItens["ITEM_ID"]);
            string descricao = Convert.ToString(leitorItens["ITEM_DESCRICAO"]);
            decimal valor = Convert.ToDecimal(leitorItens["ITEM_VALOR"]);

            return new Item(id, descricao, valor);
        }

        public List<Item> SelecionarTodos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodos;

            //executa o comando
            SqlDataReader leitorItens = comandoSelecionarTodos.ExecuteReader();

            List<Item> items = new List<Item>();

            while (leitorItens.Read())
            {
                Item item = ConverterParaItem(leitorItens);

                items.Add(item);
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return items;
        }

        private void ConfigurarParametros(SqlCommand comandoInserir, Item item)
        {
            comandoInserir.Parameters.AddWithValue("ID", item.id);
            comandoInserir.Parameters.AddWithValue("DESCRICAO", item.descricao);
            comandoInserir.Parameters.AddWithValue("VALOR", item.valor);
        }
    }
}
