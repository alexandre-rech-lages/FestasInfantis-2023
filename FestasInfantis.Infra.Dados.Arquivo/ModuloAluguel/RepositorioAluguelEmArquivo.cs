using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.Infra.Dados.Arquivo.ModuloAluguel
{
    public class RepositorioAluguelEmArquivo : RepositorioEmArquivoBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmArquivo(ContextoDados contexto) : base(contexto)
        {
        }

        public List<Aluguel> SelecionarConcluidas()
        {
            return ObterRegistros()
                .Where(x => x.Concluido).ToList();
        }

        public List<Aluguel> SelecionarPendentes()
        {
            return ObterRegistros()
                .Where(x => x.Concluido == false).ToList();
        }

        protected override List<Aluguel> ObterRegistros()
        {
            return contextoDados.alugueis;
        }
    }
}
