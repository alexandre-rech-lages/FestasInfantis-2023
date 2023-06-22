using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Infra.Dados.Memoria.Compartilhado;

namespace FestasInfantis.Infra.Dados.Memoria.ModuloItem
{
    public class RepositorioItemEmMemoria : RepositorioEmMemoriaBase<Item>, IRepositorioItem
    {
        public RepositorioItemEmMemoria(List<Item> itens) : base(itens)
        {
        }
    }
}
