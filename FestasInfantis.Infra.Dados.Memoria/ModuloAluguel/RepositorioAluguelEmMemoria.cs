using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Memoria.Compartilhado;

namespace FestasInfantis.Infra.Dados.Memoria.ModuloAluguel
{
    public class RepositorioAluguelEmMemoria : RepositorioEmMemoriaBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmMemoria(List<Aluguel> alugueis) : base(alugueis)
        {
        }

        public List<Aluguel> SelecionarConcluidas()
        {
            return listaRegistros.FindAll(aluguel => aluguel.PagamentoConcluido);
        }

        public List<Aluguel> SelecionarPendentes()
        {
            return listaRegistros.FindAll(aluguel => !aluguel.PagamentoConcluido);
        }

        public bool VerificarAlugueisAbertosCliente(Cliente cliente)
        {
            return listaRegistros
                .Any(aluguel => aluguel.PagamentoConcluido == false && aluguel.Cliente == cliente) == false;
        }

        public bool VerificarTemasIndisponiveis(Tema tema)
        {
            return listaRegistros
                .Any(aluguel => aluguel.PagamentoConcluido == false && aluguel.Tema == tema) == false;
        }
    }
}
