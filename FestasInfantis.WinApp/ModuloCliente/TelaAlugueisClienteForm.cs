using FestasInfantis.Dominio.ModuloCliente;

namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TelaAlugueisClienteForm : Form
    {
        public TelaAlugueisClienteForm()
        {
            InitializeComponent();
        }

        public void ConfigurarTela(Cliente cliente)
        {
            txtId.Text = cliente.id.ToString();
            txtNome.Text = cliente.nome;

            tabelaAlugueisClienteControl1.AtualizarRegistros(cliente.Alugueis);
        }
    }
}
