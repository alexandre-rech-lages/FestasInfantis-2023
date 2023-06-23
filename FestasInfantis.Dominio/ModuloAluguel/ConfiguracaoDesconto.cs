namespace FestasInfantis.Dominio.ModuloAluguel
{
    [Serializable]
    public class ConfiguracaoDesconto
    {
        public decimal PorcentagemDesconto { get; set; }
        public decimal PorcentagemMaxima { get; set; }

        public ConfiguracaoDesconto()
        {
            PorcentagemDesconto = 1m;
            PorcentagemMaxima = 15;
        }

        public ConfiguracaoDesconto(decimal porcentagemPorDesconto, decimal porcentagemMaxima)
        {
            PorcentagemDesconto = porcentagemPorDesconto;
            PorcentagemMaxima = porcentagemMaxima;
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (PorcentagemDesconto > PorcentagemMaxima)
                erros.Add("A porcentagem de desconto não pode ultrapassar a porcentagem máxima!");

            return erros.ToArray();
        }
    }
}
