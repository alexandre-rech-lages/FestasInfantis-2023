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
            this.Itens = new List<Item>();
        }

        public Tema(string nome) : this()
        {
            this.nome = nome;
        }

        public Tema(int idTema, string nome) : this()
        {
            this.id = idTema;
            this.nome = nome;
        }

        public void AdicionarItem(Item item)
        {
            if (Itens.Contains(item) == false)
                Itens.Add(item);
        }

        public decimal CalcularValor()
        {
            if (Itens != null)
                return Itens.Aggregate(0m, (soma, item) => soma + item.valor);

            return 0;
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

            return erros.ToArray();
        }

        public bool Contem(Item item)
        {
            return Itens.Contains(item);
        }
    }
}
