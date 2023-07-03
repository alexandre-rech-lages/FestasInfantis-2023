using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.Dominio.ModuloTema
{
    public interface IRepositorioTema
    {
        void Inserir(Tema tema, List<Item> itensAdicionados);

        void Editar(int id, Tema tema, List<Item> itensMarcados, List<Item> itensDesmarcados);
        void Excluir(Tema temaSelecionado);
        List<Tema> SelecionarTodos(bool carregarItens = false, bool carregarAlugueis = false);
        Tema SelecionarPorId(int id);
    }
}
