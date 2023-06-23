using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;

namespace FestasInfantis.Infra.Dados.Memoria.ModuloCliente
{
    public class RepositorioClienteEmArquivo : RepositorioEmArquivoBase<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
        }

        protected override List<Cliente> ObterRegistros()
        {
            return contextoDados.clientes;
        }

        public void RegistrarAluguelDoCliente(Cliente cliente, Aluguel aluguelEfetuado)
        {
            cliente.RegistrarAluguel(aluguelEfetuado);

            Editar(cliente.id, cliente);
        }
    }
}
