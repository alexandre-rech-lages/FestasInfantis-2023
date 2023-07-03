using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.Infra.Dados.Arquivo.ModuleTema
{
    public class RepositorioTemaEmArquivo: RepositorioEmArquivoBase<Tema>, IRepositorioTema
    {
        public RepositorioTemaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
        }

        public void Editar(int id, Tema tema, List<Item> itensMarcados, List<Item> itensDesmarcados)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Tema tema, List<Item> itensAdicionados)
        {
            throw new NotImplementedException();
        }

        public List<Tema> SelecionarTodos(bool carregarItens = false)
        {
            throw new NotImplementedException();
        }

        public List<Tema> SelecionarTodos(bool carregarItens = false, bool carregarAlugueis = false)
        {
            throw new NotImplementedException();
        }

        protected override List<Tema> ObterRegistros()
        {
            return contextoDados.temas;
        }
    }
}
