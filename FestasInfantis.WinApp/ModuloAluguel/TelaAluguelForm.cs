using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private List<Cliente> clientes;
        private List<Tema> temas;
        private ConfiguracaoDesconto configuracaoDesconto;

        private Aluguel aluguel;

        public TelaAluguelForm(ConfiguracaoDesconto configuracaoDesconto, List<Cliente> clientes, List<Tema> temas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.configuracaoDesconto = configuracaoDesconto;

            this.clientes = clientes;
            this.temas = temas;

            ConfigurarComboBoxes();
        }

        public Cliente ObterClienteSelecionado()
        {
            return clientes.Find(c => c == cmbClientes.SelectedItem)!;
        }

        public Aluguel ObterAluguel()
        {
            int id = Convert.ToInt32(txtId.Text);

            DateTime data = txtDataFesta.Value;

            TimeSpan horarioInicio = TimeSpan.Parse(txtHorarioInicio.Text);
            TimeSpan horarioTermino = TimeSpan.Parse(txtHorarioTermino.Text);

            Festa festa = new Festa(ObterDadosEndereco(), data, horarioInicio, horarioTermino);

            Cliente cliente = clientes.Find(c => c == cmbClientes.SelectedItem)!;

            Tema tema = temas.Find(t => t == cmbTemas.SelectedItem)!;

            decimal porcentagemEntrada = Convert.ToDecimal(cmbEntrada.SelectedItem);

            decimal porcentagemDesconto = Convert.ToDecimal(txtPorcentagemDesconto.Text);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemEntrada, porcentagemDesconto);

            if (id > 0)
                aluguel.id = id;

            return aluguel;
        }

        public void ConfigurarTela(Aluguel aluguel)
        {
            this.aluguel = aluguel;

            txtId.Text = aluguel.id.ToString();

            txtDataFesta.Text = aluguel.Festa?.Data.ToString();

            txtHorarioInicio.Text = aluguel.Festa?.HorarioInicio.ToString();
            txtHorarioTermino.Text = aluguel.Festa?.HorarioTermino.ToString();

            txtCidade.Text = aluguel.Festa?.Endereco.Cidade;
            txtEstado.Text = aluguel.Festa?.Endereco.Estado;
            txtRua.Text = aluguel.Festa?.Endereco.Rua;
            txtBairro.Text = aluguel.Festa?.Endereco.Bairro;
            txtNumero.Text = aluguel.Festa?.Endereco.Numero;

            cmbClientes.SelectedItem = aluguel.Cliente;

            cmbTemas.SelectedItem = aluguel.Tema;

            cmbEntrada.SelectedItem = aluguel.PorcentagemSinal;
        }

        private void ConfigurarComboBoxes()
        {
            cmbClientes.Items.Clear();

            foreach (Cliente cliente in clientes)
                cmbClientes.Items.Add(cliente);

            cmbTemas.Items.Clear();

            foreach (Tema tema in temas)
                cmbTemas.Items.Add(tema);

            cmbEntrada.Items.Add(40m);
            cmbEntrada.Items.Add(50m);
            cmbEntrada.SelectedIndex = 0;
        }

        private Endereco ObterDadosEndereco()
        {
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string rua = txtRua.Text;
            string bairro = txtBairro.Text;
            string numero = txtNumero.Text;

            return new Endereco(rua, bairro, cidade, estado, numero);
        }

        private void AtualizarTabelaValores()
        {
            Aluguel aluguel1 = ObterAluguel();

            txtValorPendente.Text = aluguel1.CalcularValorPendente().ToString();
            txtValorSinal.Text = aluguel1.CalcularValorSinal().ToString();
            txtValorDesconto.Text = aluguel1.CalcularValorDesconto().ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = ObterAluguel();

            string[] erros = aluguel.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private void AtualizarPorcentagemDesconto(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = clientes.Find(c => c == cmbClientes.SelectedItem);

            aluguel.Cliente = clienteSelecionado;

            decimal porcentagemDesconto = clienteSelecionado.CalcularDesconto(configuracaoDesconto);

            txtPorcentagemDesconto.Text = porcentagemDesconto.ToString();

            if (clienteSelecionado != null)
                pnlTema.Enabled = true;
            else
                pnlTema.Enabled = false;
        }

        private void AtualizarValorTotal(object sender, EventArgs e)
        {
            Tema temaSelecionado = temas.Find(t => t == cmbTemas.SelectedItem);

            aluguel.Tema = temaSelecionado;

            txtValorTema.Text = temaSelecionado.Valor.ToString();

            if (temaSelecionado != null)
                pnlDadosAluguel.Enabled = true;
            else
                pnlDadosAluguel.Enabled = false;

            AtualizarTabelaValores();
        }

        private void AtualizarPorcentagemEntrada(object sender, EventArgs e)
        {
            Tema temaSelecionado = temas.Find(t => t == cmbTemas.SelectedItem);

            if (temaSelecionado != null)
                AtualizarTabelaValores();
        }
    }
}
