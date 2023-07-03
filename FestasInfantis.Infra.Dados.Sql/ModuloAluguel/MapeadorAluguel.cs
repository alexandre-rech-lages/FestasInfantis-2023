using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Sql.Compartilhado;
using FestasInfantis.Infra.Dados.Sql.ModuloCliente;
using FestasInfantis.Infra.Dados.Sql.ModuloTema;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloAluguel
{
    public class MapeadorAluguel : MapeadorBase<Aluguel>
    {
        public override void ConfigurarParametros(SqlCommand comando, Aluguel registro)
        {
            comando.Parameters.AddWithValue("ID", registro.id);

            comando.Parameters.AddWithValue("PORCENTAGEMSINAL", registro.PorcentagemSinal);
            comando.Parameters.AddWithValue("PORCENTAGEMDESCONTO", registro.PorcentagemDesconto);

            if (registro.DataPagamento == null)
                comando.Parameters.AddWithValue("DATAPAGAMENTO", DBNull.Value);
            else
                comando.Parameters.AddWithValue("DATAPAGAMENTO", registro.DataPagamento);

            comando.Parameters.AddWithValue("PAGAMENTOCONCLUIDO", registro.PagamentoConcluido);
            comando.Parameters.AddWithValue("FESTA_DATA", registro.Festa.Data);
            comando.Parameters.AddWithValue("FESTA_HORARIOINICIO", registro.Festa.HorarioInicio.Ticks);
            comando.Parameters.AddWithValue("FESTA_HORARIOTERMINO", registro.Festa.HorarioTermino.Ticks);
            comando.Parameters.AddWithValue("ENDERECO_ESTADO", registro.Festa.Endereco.Estado);
            comando.Parameters.AddWithValue("ENDERECO_CIDADE", registro.Festa.Endereco.Cidade);
            comando.Parameters.AddWithValue("ENDERECO_BAIRRO", registro.Festa.Endereco.Bairro);
            comando.Parameters.AddWithValue("ENDERECO_RUA", registro.Festa.Endereco.Rua);
            comando.Parameters.AddWithValue("ENDERECO_NUMERO", registro.Festa.Endereco.Numero);

            comando.Parameters.AddWithValue("CONFIGURACAO_PORCENTAGEMDESCONTO", registro.ConfiguracaoDesconto.PorcentagemDesconto);
            comando.Parameters.AddWithValue("CONFIGURACAO_PORCENTAGEMMAXIMA", registro.ConfiguracaoDesconto.PorcentagemMaxima);

            comando.Parameters.AddWithValue("TEMA_ID", registro.Tema.id);
            comando.Parameters.AddWithValue("CLIENTE_ID", registro.Cliente.id);
        }

        public override Aluguel ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["ALUGUEL_ID"]);
            decimal porcentagemSinal = Convert.ToDecimal(leitorRegistros["ALUGUEL_PORCENTAGEM_SINAL"]);
            decimal porcentagemDesconto = Convert.ToDecimal(leitorRegistros["ALUGUEL_PORCENTAGEM_DESCONTO"]);

            ConverterParaConfiguracaoDesconto(leitorRegistros);

            bool pagamentoConcluido = false;
            DateTime dataPagamento = DateTime.MinValue;

            if (leitorRegistros["ALUGUEL_DATA_PAGAMENTO"] != DBNull.Value)
            {
                dataPagamento = Convert.ToDateTime(leitorRegistros["ALUGUEL_DATA_PAGAMENTO"]);
                pagamentoConcluido = Convert.ToBoolean(leitorRegistros["ALUGUEL_PAGAMENTO_CONCLUIDO"]);
            }

            ConfiguracaoDesconto configuracaoDesconto = ConverterParaConfiguracaoDesconto(leitorRegistros);

            Festa festa = ConverterParaFesta(leitorRegistros);

            Tema tema = new MapeadorTema().ConverterRegistro(leitorRegistros);

            Cliente cliente = new MapeadorCliente().ConverterRegistro(leitorRegistros);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemSinal, porcentagemDesconto);

            aluguel.id = id;
            aluguel.PagamentoConcluido = pagamentoConcluido;
            aluguel.DataPagamento = dataPagamento;
            aluguel.ConfiguracaoDesconto = configuracaoDesconto;

            return aluguel;
        }

        private static ConfiguracaoDesconto ConverterParaConfiguracaoDesconto(SqlDataReader leitorAlugueis)
        {
            decimal configuracaoPorcentagemDesconto = Convert.ToDecimal(leitorAlugueis["ALUGUEL_CONFIGURACAO_PORCENTAGEM_DESCONTO"]);
            decimal configuracaoPorcentagemMaxima = Convert.ToDecimal(leitorAlugueis["ALUGUEL_CONFIGURACAO_PORCENTAGEM_MAXIMA"]);

            ConfiguracaoDesconto configuracaoDesconto = new ConfiguracaoDesconto(configuracaoPorcentagemDesconto, configuracaoPorcentagemMaxima);

            return configuracaoDesconto;
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
