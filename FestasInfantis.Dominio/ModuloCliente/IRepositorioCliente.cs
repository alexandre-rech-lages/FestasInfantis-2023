namespace FestasInfantis.Dominio.ModuloCliente
{
    public interface IRepositorioCliente
    {
        void Inserir(Cliente novoCliente);
        void Editar(int id, Cliente cliente);
        void Excluir(Cliente clienteSelecionado);
        List<Cliente> SelecionarTodos(bool carregarAlugueis = false);
        Cliente SelecionarPorId(int id);
    }
}
