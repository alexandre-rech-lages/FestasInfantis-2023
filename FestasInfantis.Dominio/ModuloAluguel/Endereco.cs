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
    }
}
