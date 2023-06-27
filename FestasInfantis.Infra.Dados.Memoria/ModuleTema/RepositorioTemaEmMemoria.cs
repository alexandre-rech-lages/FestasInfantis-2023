using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Infra.Dados.Memoria.Compartilhado;

namespace FestasInfantis.Infra.Dados.Memoria.ModuleTema
{
    public class RepositorioTemaEmMemoria: RepositorioEmMemoriaBase<Tema>, IRepositorioTema
    {
        public RepositorioTemaEmMemoria(List<Tema> temas) : base(temas)
        {
        }

        public void Inserir(Tema tema, List<Item> itensAdicionados)
        {
            throw new NotImplementedException();
        }
    }
}
