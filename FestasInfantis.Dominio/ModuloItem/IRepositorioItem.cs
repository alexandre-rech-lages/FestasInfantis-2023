namespace FestasInfantis.Dominio.ModuloItem
{
    public interface IRepositorioItem
    {
        void Inserir(Item novoItem);
        void Editar(int id, Item item);
        void Excluir(Item itemSelecionado);
        List<Item> SelecionarTodos();
        Item SelecionarPorId(int id);
    }
}
