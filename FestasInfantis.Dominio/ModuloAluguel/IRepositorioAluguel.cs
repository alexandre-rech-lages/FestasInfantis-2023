using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel
    {
        void Inserir(Aluguel novoAluguel);
        void Editar(int id, Aluguel aluguel);
        void Excluir(Aluguel aluguelSelecionado);
        List<Aluguel> SelecionarTodos();
        Aluguel SelecionarPorId(int id);
        List<Aluguel> SelecionarConcluidos();
        List<Aluguel> SelecionarPendentes();
        bool VerificarAlugueisAbertosCliente(Cliente cliente);
        bool VerificarTemasIndisponiveis(Tema tema);
    }
}
