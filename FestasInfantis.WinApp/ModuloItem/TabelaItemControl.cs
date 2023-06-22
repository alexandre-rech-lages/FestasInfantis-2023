using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.WinApp.ModuloItem
{
    public partial class TabelaItemControl : UserControl
    {
        public TabelaItemControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridItens.ConfigurarGridZebrado();

            gridItens.ConfigurarGridSomenteLeitura();
        }

        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "descricao",
                    HeaderText = "Descricao"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "valor",
                    HeaderText = "Valor"
                }
            };

            gridItens.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Item> itens)
        {
            gridItens.Rows.Clear();

            foreach (Item item in itens)
            {
                gridItens.Rows.Add(item.id, item.descricao, item.valor);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridItens.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridItens.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
