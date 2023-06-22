using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;
using System.Data;

namespace FestasInfantis.WinApp.ModuloTema
{
    public partial class TelaSelecaoItensForm : Form
    {
        private List<Item> itensDisponiveis;

        public TelaSelecaoItensForm(List<Item> itensDisponiveis, Tema tema)
        {
            InitializeComponent();

            this.itensDisponiveis = itensDisponiveis;

            ConfigurarTela(tema);
        }

        public List<Item> ObterItensMarcados()
        {
            return listItensTema.CheckedItems.Cast<Item>().ToList();
        }

        private void ConfigurarTela(Tema tema)
        {
            listItensTema.Items.Clear();

            int i = 0;

            foreach (Item item in itensDisponiveis)
            {
                listItensTema.Items.Add(item);

                if (tema.Itens != null && tema.Itens.Contains(item))
                    listItensTema.SetItemChecked(i, true);

                i++;
            }
        }
    }
}
