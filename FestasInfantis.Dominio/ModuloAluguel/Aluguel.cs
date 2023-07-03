using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.Dominio.ModuloAluguel
{
    [Serializable]
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Festa Festa { get; set; }

        public Cliente Cliente { get; set; }
        public Tema Tema { get; set; }
        public ConfiguracaoDesconto ConfiguracaoDesconto { get; set; }
        public decimal PorcentagemSinal { get; set; }
        public decimal PorcentagemDesconto { get; set; }
        public DateTime? DataPagamento { get; set; }
        public bool PagamentoConcluido { get; set; }

        public Aluguel()
        {
            Cliente = new Cliente();
            Tema = new Tema();
        }

        public Aluguel(Cliente cliente, Festa festa, Tema tema, decimal porcentagemSinal, decimal porcentagemDesconto)
        {
            Cliente = cliente;
            Festa = festa;
            Tema = tema;
            PorcentagemSinal = porcentagemSinal;
            PorcentagemDesconto = porcentagemDesconto;
            PagamentoConcluido = false;
            DataPagamento = null;
        }


        public void Concluir()
        {
            DataPagamento = DateTime.Now;
            PagamentoConcluido = true;
        }

        public override void AtualizarInformacoes(Aluguel registroAtualizado)
        {
            Cliente = registroAtualizado.Cliente;
            Festa = registroAtualizado.Festa;
            Tema = registroAtualizado.Tema;
            PorcentagemDesconto = registroAtualizado.PorcentagemDesconto;
            PorcentagemSinal = registroAtualizado.PorcentagemSinal;
            DataPagamento = registroAtualizado.DataPagamento;
            PagamentoConcluido = registroAtualizado.PagamentoConcluido;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (Festa != null)
                erros.AddRange(Festa.Validar());

            if (Cliente == null)
                erros.Add("O campo 'Cliente' é obrigatório");

            if (Tema == null)
                erros.Add("O campo 'Tema' é obrigatório");

            if (PorcentagemSinal <= 0)
                erros.Add("O campo '% do Sinal' é obrigatório");

            return erros.ToArray();
        }

        public DadosPagamentoAluguel ObterDadosPagamento()
        {
            decimal percentualCliente = Cliente.CalcularDesconto(ConfiguracaoDesconto);

            decimal valorTemaComDesconto = Tema.CalcularValorComDesconto(percentualCliente);

            decimal valorSinal = valorTemaComDesconto - (valorTemaComDesconto * PorcentagemSinal / 100);

            decimal valorPendente = valorTemaComDesconto - valorSinal;

            DadosPagamentoAluguel dados = new DadosPagamentoAluguel();

            dados.ValorComDesconto = valorTemaComDesconto;
            dados.ValorPendente = valorPendente;
            dados.ValorSinal = valorSinal;
            dados.ValorPercentualCliente = percentualCliente;
            dados.ValorTema = Tema.Valor;

            return dados;
        }
    }

    public class DadosPagamentoAluguel
    {
        public decimal ValorSinal;
        public decimal ValorComDesconto;
        public decimal ValorPendente;
        public decimal ValorPercentualCliente;
        public decimal ValorTema;
    }
}
