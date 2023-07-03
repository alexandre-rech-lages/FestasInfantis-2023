using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Sql.Compartilhado;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloTema
{
    internal class MapeadorTema : MapeadorBase<Tema>
    {
        public override void ConfigurarParametros(SqlCommand comando, Tema registro)
        {
            throw new NotImplementedException();
        }

        public override Tema ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["TEMA_ID"]);

            string nome = Convert.ToString(leitorRegistros["TEMA_NOME"]);

            decimal valor = Convert.ToDecimal(leitorRegistros["TEMA_VALOR"]);

            Tema tema = new Tema(id, nome, valor);

            return tema;
        }
    }
}
