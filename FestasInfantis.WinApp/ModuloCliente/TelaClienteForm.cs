using FestasInfantis.Dominio.ModuloCliente;

namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TelaClienteForm : Form
    {
        public TelaClienteForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Cliente ObterCliente()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtNome.Text;

            string telefone = txtTelefone.Text;

            Cliente cliente = new Cliente(nome, telefone);

            if (id > 0)
                cliente.id = id;

            return cliente;
        }

        public void ConfigurarTela(Cliente cliente)
        {
            txtId.Text = cliente.id.ToString();

            txtNome.Text = cliente.nome;

            txtTelefone.Text = cliente.telefone;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Cliente Cliente = ObterCliente();

            string[] erros = Cliente.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
