namespace FestasInfantis.Dominio.ModuloItem
{
    [Serializable]
    public class Item : EntidadeBase<Item>
    {
        public string descricao;
        public decimal valor;

        public Item()
        {
            
        }

        public Item(string descricao, decimal valor)
        {
            this.descricao = descricao;
            this.valor = valor;
        }

        public Item(int id, string descricao, decimal valor)
        {
            this.id = id;
            this.descricao = descricao;
            this.valor = valor;
        }

        public override void AtualizarInformacoes(Item registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.descricao = registroAtualizado.descricao;
            this.valor = registroAtualizado.valor;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(descricao))
                erros.Add("O campo 'Descrição' é obrigatório");

            if (descricao.Length < 3 )
                erros.Add("O campo 'Descrição' deve conter no mínimo 3 caracteres");

            if (valor < 1)
                erros.Add("O campo 'Valor' não pode receber o valor 0");

            return erros.ToArray();
        }

        public override string ToString()
        {
            return $"Id: {id} Descrição: {descricao} Valor: {valor}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Item item &&
                   id == item.id &&
                   descricao == item.descricao &&
                   valor == item.valor;
        }
    }
}
