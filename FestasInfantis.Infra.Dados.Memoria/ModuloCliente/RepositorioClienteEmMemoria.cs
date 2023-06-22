using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Infra.Dados.Memoria.Compartilhado;

namespace FestasInfantis.Infra.Dados.Memoria.ModuloCliente
{
    public class RepositorioClienteEmMemoria : RepositorioEmMemoriaBase<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmMemoria(List<Cliente> clientes) : base(clientes)
        {
        }
    }
}
