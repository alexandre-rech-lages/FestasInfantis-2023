using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {
        public TabelaAluguelControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridAlugueis.ConfigurarGridZebrado();

            gridAlugueis.ConfigurarGridSomenteLeitura();
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
                    HeaderText = "Nome do Cliente"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "tema",
                    HeaderText = "Tema"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "data",
                    HeaderText = "Data"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "valor",
                    HeaderText = "Valor"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "valorPendente",
                    HeaderText = "Valor Pendente"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "status",
                    HeaderText = "Status"
                }
            };

            gridAlugueis.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            gridAlugueis.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                gridAlugueis.Rows.Add(
                    aluguel.id, 
                    aluguel.Cliente, 
                    aluguel.Tema, 
                    aluguel.Festa.Data.ToShortDateString(), 
                    aluguel.Tema.CalcularValor(), 
                    aluguel.CalcularValorPendente(),
                    aluguel.PagamentoConcluido ? "Concluído" : "Pendente"
                );
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridAlugueis.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridAlugueis.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
