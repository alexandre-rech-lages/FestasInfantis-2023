using FestasInfantis.Dominio.ModuloCliente;

namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridClientes.ConfigurarGridZebrado();

            gridClientes.ConfigurarGridSomenteLeitura();
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
                    Name = "nome",
                    HeaderText = "Nome"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "telefone",
                    HeaderText = "Telefone"
                }
            };

            gridClientes.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            gridClientes.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {
                gridClientes.Rows.Add(cliente.id, cliente.nome, cliente.telefone);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridClientes.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridClientes.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
