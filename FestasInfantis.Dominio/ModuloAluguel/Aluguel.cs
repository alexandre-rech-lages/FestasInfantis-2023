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

        public decimal CalcularValorPendente()
        {
            return CalcularValorDesconto() - CalcularValorSinal();
        }

        public decimal CalcularValorSinal()
        {
            return Tema.Valor * PorcentagemSinal / 100;
        }

        public decimal CalcularValorDesconto()
        {
            return Tema.Valor - Tema.Valor * PorcentagemDesconto / 100;
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

            erros.AddRange(Festa.Validar());

            if (Cliente == null)
                erros.Add("O campo 'Cliente' é obrigatório");

            if (Tema == null)
                erros.Add("O campo 'Tema' é obrigatório");
                
            if (PorcentagemSinal <= 0)
                erros.Add("O campo '% do Sinal' é obrigatório");

            return erros.ToArray();
        }
    }
}
