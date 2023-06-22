namespace FestasInfantis.Dominio.ModuloTema
{
    public interface IRepositorioTema
    {
        void Inserir(Tema tema);
        void Editar(int id, Tema tema);
        void Excluir(Tema temaSelecionado);
        List<Tema> SelecionarTodos();
        Tema SelecionarPorId(int id);
    }
}
