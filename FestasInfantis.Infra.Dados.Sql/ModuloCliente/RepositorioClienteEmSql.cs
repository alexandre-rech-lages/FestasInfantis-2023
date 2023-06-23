using FestasInfantis.Dominio.ModuloCliente;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloCliente
{
    public class RepositorioClienteEmSql : IRepositorioCliente
    {
        private const string enderecoBanco = 
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FestasInfantisDb;Integrated Security=True";

        private const string sqlInserirCliente =
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

        private const string sqlEditarCliente =
            @"UPDATE [TBCLIENTE] 
	            SET 
		            [NOME] = @NOME,
		            [TELEFONE] = @TELEFONE
	            WHERE 
		            [ID] = @ID";

        private const string sqlExcluirCliente =
            @"DELETE FROM [TBCLIENTE]
	            WHERE 
		            [ID] = @ID";

        private const string sqlSelecionarTodosClientes =
            @"SELECT 
	            [ID], 
	            [NOME], 
	            [TELEFONE] 
            FROM 
	            [TBCLIENTE]";

        private const string sqlSelecionarClientePorId =
            @"SELECT 
	            [ID], 
	            [NOME], 
	            [TELEFONE] 
            FROM 
	            [TBCLIENTE] 
            WHERE 
                [ID] = @ID";

        public void Inserir(Cliente novoCliente)
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserirCliente;

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
            comandoEditar.CommandText = sqlEditarCliente;

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
            comandoExcluir.CommandText = sqlExcluirCliente;

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
            comandoSelecionarPorId.CommandText = sqlSelecionarClientePorId;

            //adicionar parametro
            comandoSelecionarPorId.Parameters.AddWithValue("ID", id);

            //executa o comando
            SqlDataReader leitorClientes = comandoSelecionarPorId.ExecuteReader();

            Cliente cliente = null;

            if (leitorClientes.Read())            
                cliente = ConverterParaCliente(leitorClientes);            

            //encerra a conexão
            conexaoComBanco.Close();

            return cliente;
        }
      
        public List<Cliente> SelecionarTodos()
        {
            //obter a conexão com o banco e abrir ela
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            //cria um comando e relaciona com a conexão aberta
            SqlCommand comandoSelecionarTodos = conexaoComBanco.CreateCommand();
            comandoSelecionarTodos.CommandText = sqlSelecionarTodosClientes;            

            //executa o comando
            SqlDataReader leitorClientes = comandoSelecionarTodos.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (leitorClientes.Read())
            {
                Cliente cliente = ConverterParaCliente(leitorClientes);

                clientes.Add(cliente);  
            }

            //encerra a conexão
            conexaoComBanco.Close();

            return clientes;
        }


        private static Cliente ConverterParaCliente(SqlDataReader leitorClientes)
        {
            int id = Convert.ToInt32(leitorClientes["ID"]);

            string nome = Convert.ToString(leitorClientes["NOME"]);

            string telefone = Convert.ToString(leitorClientes["TELEFONE"]);

            return new Cliente(id, nome, telefone);
        }


        private void ConfigurarParametros(SqlCommand comandoInserir, Cliente novoCliente)
        {
            comandoInserir.Parameters.AddWithValue("ID", novoCliente.id);

            comandoInserir.Parameters.AddWithValue("NOME", novoCliente.nome);

            comandoInserir.Parameters.AddWithValue("TELEFONE", novoCliente.telefone);
        }
    }
}
