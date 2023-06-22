using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.WinApp.ModuloItem
{
    public partial class TelaItemForm : Form
    {
        public TelaItemForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Item ObterItem()
        {
            int id = Convert.ToInt32(txtId.Text);

            string descricao = txtNome.Text;

            decimal valor = txtValor.Value;

            Item item = new Item(descricao, valor);

            if (id > 0)
                item.id = id;

            return item;
        }

        public void ConfigurarTela(Item item)
        {
            txtId.Text = item.id.ToString();

            txtNome.Text = item.descricao;

            txtValor.Value = item.valor;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Item item = ObterItem();

            string[] erros = item.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
