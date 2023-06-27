using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloTema
{
    public partial class TelaTemaForm : Form
    {
        private Tema tema;

        public TelaTemaForm(List<Item> itensDisponiveis)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarItens(itensDisponiveis);
        }

        public Tema ObterTema()
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = txtNome.Text;

            tema.nome = nome;

            if (id > 0)
            {
                tema.id = id;
            }

            return tema;
        }

        public List<Item> ObterItensMarcados()
        {
            return listItensTema.CheckedItems.Cast<Item>().ToList();
        }

        public List<Item> ObterItensDesmarcados()
        {
            return listItensTema.Items.Cast<Item>()
                .Except(ObterItensMarcados()).ToList();
        }

        public void ConfigurarTela(Tema tema)
        {
            this.tema = tema;

            txtId.Text = tema.id.ToString();

            txtNome.Text = tema.nome;

            int i = 0;

            for (int j = 0; j < listItensTema.Items.Count; j++)
            {
                Item item = (Item)listItensTema.Items[j];

                if (tema.Itens.Contains(item))
                    listItensTema.SetItemChecked(i, true);

                i++;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Tema tema = ObterTema();            

            string[] erros = tema.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private void CarregarItens(List<Item> itensSelecionados)
        {
            listItensTema.Items.Clear();

            foreach (Item item in itensSelecionados)
            {
                listItensTema.Items.Add(item);
            }
        }

       
    }
}
