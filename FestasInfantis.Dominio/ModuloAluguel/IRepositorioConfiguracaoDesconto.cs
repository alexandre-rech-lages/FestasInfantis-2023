namespace FestasInfantis.Dominio.ModuloAluguel
{
    public interface IRepositorioConfiguracaoDesconto
    {
        void GravarConfiguracoesDesconto(ConfiguracaoDesconto configuracaoDesconto);
        ConfiguracaoDesconto ObterConfiguracaoDeDesconto();
    }
}
