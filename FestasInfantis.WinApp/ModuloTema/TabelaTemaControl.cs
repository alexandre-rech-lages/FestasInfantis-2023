using FestasInfantis.Dominio.ModuloTema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestasInfantis.WinApp.ModuloTema
{
    public partial class TabelaTemaControl : UserControl
    {
        public TabelaTemaControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridTemas.ConfigurarGridZebrado();

            gridTemas.ConfigurarGridSomenteLeitura();
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
                    Name = "valor",
                    HeaderText = "Valor"
                }
            };

            gridTemas.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Tema> temas)
        {
            gridTemas.Rows.Clear();

            foreach (Tema tema in temas)
            {
                gridTemas.Rows.Add(tema.id, tema.nome, tema.CalcularValor());
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridTemas.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridTemas.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
