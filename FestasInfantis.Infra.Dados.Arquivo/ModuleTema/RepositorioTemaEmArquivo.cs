using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.Infra.Dados.Arquivo.ModuleTema
{
    public class RepositorioTemaEmArquivo: RepositorioEmArquivoBase<Tema>, IRepositorioTema
    {
        public RepositorioTemaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
        }

        protected override List<Tema> ObterRegistros()
        {
            return contextoDados.temas;
        }
    }
}
