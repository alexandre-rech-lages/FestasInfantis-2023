using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaFiltroAluguelForm : Form
    {
        public TelaFiltroAluguelForm()
        {
            InitializeComponent();
        }

        public StatusAluguelEnum ObterFiltroAluguel()
        {
            if (rdbAlugueisConcluidos.Checked == true)
                return StatusAluguelEnum.Concluidos;

            else if (rdbAlugueisPendentes.Checked == true)
                return StatusAluguelEnum.Pendentes;

            return StatusAluguelEnum.Todos;
        }
    }
}
