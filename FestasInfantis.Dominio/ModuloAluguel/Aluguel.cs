using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.Dominio.ModuloAluguel
{
    [Serializable]
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Cliente Cliente { get; set; }
        public Festa Festa { get; set; }
        public Tema Tema { get; set; }
        public decimal PorcentagemSinal { get; set; }
        public decimal PorcentagemDesconto { get; set; }
        public bool Concluido { get; set; }

        public Aluguel()
        {            
        }

        public Aluguel(int id, Cliente cliente, Festa festa, Tema tema, decimal porcentagemSinal, decimal porcentagemDesconto)
        {
            this.id = id;
            Cliente = cliente;
            Festa = festa;
            Tema = tema;
            PorcentagemSinal = porcentagemSinal;
            PorcentagemDesconto = porcentagemDesconto;
            Concluido = false;

            Cliente.AdicionarAluguel(this);
        }

        public Aluguel(Cliente cliente, Festa festa, Tema tema, decimal porcentagemSinal, decimal porcentagemDesconto)
        {
            Cliente = cliente;
            Festa = festa;
            Tema = tema;
            PorcentagemSinal = porcentagemSinal;
            PorcentagemDesconto = porcentagemDesconto;
            Concluido = false;

            Cliente.AdicionarAluguel(this);
        }

        public decimal CalcularValorPendente()
        {
            return CalcularValorDesconto() - CalcularValorSinal();
        }

        public decimal CalcularValorSinal()
        {
            return Tema.CalcularValor() * PorcentagemSinal / 100;
        }

        public decimal CalcularValorDesconto()
        {
            return Tema.CalcularValor() - Tema.CalcularValor() * PorcentagemDesconto / 100;
        }

        public void Concluir()
        {
            Concluido = true;
        }

        public override void AtualizarInformacoes(Aluguel registroAtualizado)
        {
            Cliente = registroAtualizado.Cliente;
            Festa = registroAtualizado.Festa;
            Tema = registroAtualizado.Tema;
            PorcentagemDesconto = registroAtualizado.PorcentagemDesconto;
            PorcentagemSinal = registroAtualizado.PorcentagemSinal;
            Concluido = registroAtualizado.Concluido;
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
