using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.Dominio.ModuloCliente
{
    [Serializable]
    public class Cliente : EntidadeBase<Cliente>
    {
        public string nome { get; set; }
        
        public string telefone { get; set; }

        public List<Aluguel> Alugueis { get; set; } = new List<Aluguel>();

        public int QuantidadeAlugueis { get { return Alugueis.Where(x => x.Concluido).Count(); } }

        public Cliente()
        {
            
        }
        public Cliente(string nome, string telefone)
        {
            this.nome = nome;
            this.telefone = telefone;
        }

        public Cliente(int id, string nome, string telefone)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
        }

        public void AdicionarAluguel(Aluguel aluguel)
        {
            Alugueis.Add(aluguel);
        }

        public override void AtualizarInformacoes(Cliente registroAtualizado)
        {
            this.nome = registroAtualizado.nome;
            this.telefone = registroAtualizado.telefone;
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

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   id == cliente.id &&
                   nome == cliente.nome &&
                   telefone == cliente.telefone;
        }

        public decimal CalcularDesconto(ConfiguracaoDesconto configuracaoDesconto)
        {
            decimal desconto = QuantidadeAlugueis * configuracaoDesconto.PorcentagemDesconto;

            if (desconto > configuracaoDesconto.PorcentagemMaxima)
                desconto = configuracaoDesconto.PorcentagemMaxima;

            return desconto;
        }
    }
}