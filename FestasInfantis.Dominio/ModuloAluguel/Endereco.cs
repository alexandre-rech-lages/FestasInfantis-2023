namespace FestasInfantis.Dominio.ModuloAluguel
{
    [Serializable]
    public class Endereco
    {
        public Endereco()
        {
        }
        public Endereco(string rua, string bairro, string cidade, string estado, string numero)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
        }

        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Bairro}, {Numero}, {Cidade}, {Estado}";
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Cidade))
                erros.Add("O campo 'Cidade' é obrigatório!");

            if (string.IsNullOrEmpty(Estado))
                erros.Add("O campo 'Estado' é obrigatório!");

            if (string.IsNullOrEmpty(Rua))
                erros.Add("O campo 'Rua' é obrigatório!");

            if (string.IsNullOrEmpty(Bairro))
                erros.Add("O campo 'Bairro' é obrigatório!");

            if (string.IsNullOrEmpty(Numero))
                erros.Add("O campo 'Número' é obrigatório!");

            return erros;
        }
    }
}
