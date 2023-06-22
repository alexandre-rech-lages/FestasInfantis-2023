using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.Dominio.Compartilhado
{
    public interface IRepositorioConfiguracaoDesconto
    {
        void GravarConfiguracoesDesconto(ConfiguracaoDesconto configuracaoDesconto);
        ConfiguracaoDesconto ObterConfiguracaoDeDesconto();
    }
}
