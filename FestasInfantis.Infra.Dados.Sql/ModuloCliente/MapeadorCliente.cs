using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Infra.Dados.Sql.Compartilhado;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(SqlCommand comando, Cliente registro)
        {
            comando.Parameters.AddWithValue("ID", registro.id);

            comando.Parameters.AddWithValue("NOME", registro.nome);

            comando.Parameters.AddWithValue("TELEFONE", registro.telefone);
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["CLIENTE_ID"]);

            string nome = Convert.ToString(leitorRegistros["CLIENTE_NOME"]);

            string telefone = Convert.ToString(leitorRegistros["CLIENTE_TELEFONE"]);

            Cliente cliente = new Cliente(id, nome, telefone);

            return cliente;
        }
    }
}
