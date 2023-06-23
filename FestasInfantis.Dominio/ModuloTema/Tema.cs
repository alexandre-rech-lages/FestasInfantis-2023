using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.Dominio.ModuloTema
{
    [Serializable]
    public class Tema : EntidadeBase<Tema>
    {
        public string nome;

        public List<Item> Itens { get; set; }

        public Tema()
        {            
        }

        public Tema(string descricao)
        {
            nome = descricao;
        }

        public void AdicionarItem(Item item)
        {
            if (Itens == null)
                Itens = new List<Item>();

            Itens.Add(item);
        }

        public decimal CalcularValor()
        {
            return Itens.Aggregate(0m, (soma, item) => soma + item.valor);
        }

        public void AtualizarItens(List<Item> itens)
        {
            Itens = itens;
        }

        public override void AtualizarInformacoes(Tema registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.nome = registroAtualizado.nome;
            this.Itens = registroAtualizado.Itens;
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

            if (nome.Length < 3)
                erros.Add("O campo 'Nome' deve conter no mínimo 3 caracteres");

            if (CalcularValor() < 1)
                erros.Add("O campo 'Valor' não pode receber o valor 0");

            return erros.ToArray();
        }
    }
}
