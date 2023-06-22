using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.Infra.Dados.Arquivo.ModuloItem
{
    public class RepositorioItemEmArquivo : RepositorioEmArquivoBase<Item>, IRepositorioItem
    {
        public RepositorioItemEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        protected override List<Item> ObterRegistros()
        {
            return contextoDados.itens;
        }
    }
}
