using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TabelaAlugueisClienteControl : UserControl
    {
        public TabelaAlugueisClienteControl()
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
                    Name = "descricao",
                    HeaderText = "Descrição do Tema"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "valor",
                    HeaderText = "Valor"
                }
            };

            gridAlugueis.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            gridAlugueis.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                gridAlugueis.Rows.Add(aluguel.id, aluguel.Tema, aluguel.Tema.CalcularValor());
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
