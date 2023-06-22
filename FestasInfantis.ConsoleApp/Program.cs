using FestasInfantis.Dominio.ModuloCliente;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cliente novoCliente = ObterCliente();

            //Inserir(novoCliente);

            //Cliente cliente = SelecionarPorId(6);

            //cliente.nome = "Alexandre Rech";
            //cliente.telefone = "49 9 99292107";

            //Editar(cliente);

            //Excluir(cliente.id);

            //List<Cliente> clientes = SelecionarTodos();
        }

        private static List<Cliente> SelecionarTodos()
        {
            //obter a conexão com o banco
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString =
                "Data Source=(localdb)\\mssqllocaldb;" +
                "Initial Catalog=FestasInfantisDb;" +
                "Integrated Security=True";
            conexaoComBanco.Open();

            //cria um comando e relaciono com uma conexão aberta
            string sqlSelecionarTodos = @"SELECT 
	                                            [ID], 
	                                            [NOME], 
	                                            [TELEFONE] 
                                            FROM 
	                                            [TBCLIENTE]";

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;
            comandoSelecao.CommandText = sqlSelecionarTodos;

            //executo o comando criado
            SqlDataReader leitorClientes = comandoSelecao.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (leitorClientes.Read())
            {
                int idCliente = Convert.ToInt32(leitorClientes["ID"]);
                string nome = Convert.ToString(leitorClientes["NOME"]);
                string telefone = Convert.ToString(leitorClientes["TELEFONE"]);

                Cliente cliente = new Cliente(idCliente, nome, telefone);

                clientes.Add(cliente);
            }

            return clientes;
        }

        private static void Excluir(int id)
        {
            //obter a conexão com o banco
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString =
                "Data Source=(localdb)\\mssqllocaldb;" +
                "Initial Catalog=FestasInfantisDb;" +
                "Integrated Security=True";
            conexaoComBanco.Open();

            //cria um comando e relaciono com uma conexão aberta
            string sqlExcluir = @"DELETE FROM [TBCliente] 
	                                WHERE [ID] = @ID";

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexaoComBanco;
            comandoExclusao.CommandText = sqlExcluir;

            //adiciona os parâmetros
            comandoExclusao.Parameters.AddWithValue("ID", id);

            //executo o comando criado
            int linhasAfetadas = comandoExclusao.ExecuteNonQuery();

            //fecho a conexão com o banco
            conexaoComBanco.Close();
        }

        private static void Editar(Cliente cliente)
        {
            //obter a conexão com o banco
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString =
                "Data Source=(localdb)\\mssqllocaldb;" +
                "Initial Catalog=FestasInfantisDb;" +
                "Integrated Security=True";
            conexaoComBanco.Open();

            //cria um comando e relaciono com uma conexão aberta
            string sqlEditar = @"UPDATE [TBCLIENTE] 
	                                SET 
		                                [NOME] = @N,
		                                [TELEFONE] = @T
	                                WHERE 
		                                [ID] = @ID";

            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = conexaoComBanco;
            comandoEdicao.CommandText = sqlEditar;

            //adiciona os parâmetros
            comandoEdicao.Parameters.AddWithValue("ID", cliente.id);
            comandoEdicao.Parameters.AddWithValue("N", cliente.nome);
            comandoEdicao.Parameters.AddWithValue("T", cliente.telefone);

            //executo o comando criado
            int linhasAfetadas = comandoEdicao.ExecuteNonQuery();

            //fecho a conexão com o banco
            conexaoComBanco.Close();
        }

        private static Cliente SelecionarPorId(int idPesquisado)
        {
            //obter a conexão com o banco
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString =
                "Data Source=(localdb)\\mssqllocaldb;" +
                "Initial Catalog=FestasInfantisDb;" +
                "Integrated Security=True";
            conexaoComBanco.Open();

            //cria um comando e relaciono com uma conexão aberta
            string sqlSelecionarPorId = @"SELECT 
	                                            [ID], 
	                                            [NOME], 
	                                            [TELEFONE] 
                                            FROM 
	                                            [TBCLIENTE]
                                            WHERE 
	                                            [ID] = @ID";

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = conexaoComBanco;
            comandoSelecao.CommandText = sqlSelecionarPorId;

            //adiciona os parâmetros
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            //executo o comando criado
            SqlDataReader leitorClientes = comandoSelecao.ExecuteReader();

            Cliente cliente = null;

            if (leitorClientes.Read())
            {
                int idCliente = Convert.ToInt32(leitorClientes["ID"]);
                string nome = Convert.ToString(leitorClientes["NOME"]);
                string telefone = Convert.ToString(leitorClientes["TELEFONE"]);

                cliente = new Cliente(idCliente, nome, telefone);
            }

            return cliente;
        }

        private static void Inserir(Cliente novoCliente)
        {
            //obter a conexão com o banco
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString =
                "Data Source=(localdb)\\mssqllocaldb;" +
                "Initial Catalog=FestasInfantisDb;" +
                "Integrated Security=True";
            conexaoComBanco.Open();

            //cria um comando e relaciono com uma conexão aberta
            string sqlInserir = @"INSERT INTO [TBCLIENTE] 
	                            (
		                            [NOME], 
		                            [TELEFONE]
	                            )
	                            VALUES 
	                            (
		                            @N, 
		                            @T
	                            );";

            sqlInserir += "Select Scope_Identity();";

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;
            comandoInsercao.CommandText = sqlInserir;

            //adiciona os parâmetros
            comandoInsercao.Parameters.AddWithValue("N", novoCliente.nome);
            comandoInsercao.Parameters.AddWithValue("T", novoCliente.telefone);

            //executo o comando criado
            object id = comandoInsercao.ExecuteScalar();

            novoCliente.id = Convert.ToInt32(id);
            //fecho a conexão com o banco
            conexaoComBanco.Close();
        }

        private static Cliente ObterCliente()
        {
            Console.WriteLine( "Digite o nome: " );

            string nome = Console.ReadLine();   

            Console.WriteLine( "Digite o telefone: " );

            string telefone = Console.ReadLine();

            return new Cliente(nome, telefone);
        }
    }
}