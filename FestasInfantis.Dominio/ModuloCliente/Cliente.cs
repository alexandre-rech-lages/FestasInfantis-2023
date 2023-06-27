using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.Dominio.ModuloCliente
{
    [Serializable]
    public class Cliente : EntidadeBase<Cliente>
    {
        public string nome { get; set; }

        public string telefone { get; set; }

        public List<Aluguel> Alugueis { get; set; } 

        public int QuantidadeAlugueisConcluidos
        {
            get
            {
                return Alugueis.Where(x => x.PagamentoConcluido).Count();
            }
        }

        public Cliente()
        {
            Alugueis = new List<Aluguel>();
        }

        public Cliente(int id, string nome, string telefone) : this ()
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
        }

        public Cliente(string nome, string telefone) : this()
        {
            this.nome = nome;
            this.telefone = telefone;
        }

        public void RegistrarAluguel(Aluguel aluguel)
        {            
            if (Alugueis.Contains(aluguel))
                return;

            Alugueis.Add(aluguel);
        }

        public override void AtualizarInformacoes(Cliente registroAtualizado)
        {
            this.nome = registroAtualizado.nome;
            this.telefone = registroAtualizado.telefone;
            this.Alugueis = registroAtualizado.Alugueis;
        }

        public override string ToString()
        {
            return $"{nome}";
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo 'Nome' é obrigatório");

            if (string.IsNullOrEmpty(telefone))
                erros.Add("O campo 'Telefone' é obrigatório");

            return erros.ToArray();
        }


        public decimal CalcularDesconto(ConfiguracaoDesconto configuracaoDesconto)
        {
            decimal desconto = QuantidadeAlugueisConcluidos * configuracaoDesconto.PorcentagemDesconto;

            if (desconto > configuracaoDesconto.PorcentagemMaxima)
                desconto = configuracaoDesconto.PorcentagemMaxima;

            return desconto;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   id == cliente.id &&
                   nome == cliente.nome &&
                   telefone == cliente.telefone &&
                   EqualityComparer<List<Aluguel>>.Default.Equals(Alugueis, cliente.Alugueis) &&
                   QuantidadeAlugueisConcluidos == cliente.QuantidadeAlugueisConcluidos;
        }
    }
}