using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Infra.Dados.Memoria.Compartilhado;

namespace FestasInfantis.Infra.Dados.Memoria.ModuloCliente
{
    public class RepositorioClienteEmMemoria : RepositorioEmMemoriaBase<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmMemoria(List<Cliente> clientes) : base(clientes)
        {
        }

        public void RegistrarAluguelDoCliente(Cliente cliente, Aluguel aluguelEfetuado)
        {
            cliente.RegistrarAluguel(aluguelEfetuado);

            Editar(cliente.id, cliente);
        }
    }
}
