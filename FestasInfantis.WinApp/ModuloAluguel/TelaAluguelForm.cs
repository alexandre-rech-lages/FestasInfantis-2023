using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private ConfiguracaoDesconto configuracaoDesconto;

        private Aluguel aluguel;

        public TelaAluguelForm(List<Cliente> clientes, List<Tema> temas)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            CarregarClientes(clientes);

            CarregarTemas(temas);

            CarregarSinais();
        }

        public Aluguel ObterAluguel()
        {
            try
            {
                aluguel.id = Convert.ToInt32(txtId.Text);

                Endereco endereco = ObterDadosEndereco();

                Festa festa = new Festa();

                festa.Data = txtDataFesta.Value;

                if (!string.IsNullOrEmpty(txtHorarioInicio.Text))
                    festa.HorarioInicio = TimeSpan.Parse(txtHorarioInicio.Text);

                if (!string.IsNullOrEmpty(txtHorarioTermino.Text))
                    festa.HorarioTermino = TimeSpan.Parse(txtHorarioTermino.Text);

                festa.Endereco = endereco;

                aluguel.Festa = festa;

                aluguel.Cliente = (Cliente)cmbClientes.SelectedItem;

                aluguel.Tema = (Tema)cmbTemas.SelectedItem;

                aluguel.PorcentagemSinal = Convert.ToDecimal(cmbEntrada.SelectedItem);

                aluguel.PorcentagemDesconto = Convert.ToDecimal(txtPorcentagemDesconto.Text);

                if (aluguel.id == 0)
                {
                    aluguel.ConfiguracaoDesconto = configuracaoDesconto;
                }
            }
            catch { }

            return aluguel;
        }

        public void ConfigurarTela(Aluguel aluguel, ConfiguracaoDesconto configuracaoDesconto)
        {
            this.aluguel = aluguel;
            this.configuracaoDesconto = configuracaoDesconto;

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

        private Endereco ObterDadosEndereco()
        {
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string rua = txtRua.Text;
            string bairro = txtBairro.Text;
            string numero = txtNumero.Text;

            return new Endereco(rua, bairro, cidade, estado, numero);
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = ObterAluguel();

            string[] erros = aluguel.Validar();

            if (erros.Length == 0)
            {
                DadosPagamentoAluguel dados = aluguel.ObterDadosPagamento();

                txtValorTema.Text = dados.ValorTema.ToString();
                txtValorDesconto.Text = dados.ValorComDesconto.ToString();
                txtValorPendente.Text = dados.ValorPendente.ToString();
                txtValorSinal.Text = dados.ValorSinal.ToString();
                txtPorcentagemDesconto.Text = dados.ValorPercentualCliente.ToString();
            }
        }

        private void CarregarSinais()
        {
            cmbEntrada.Items.Add(40m);
            cmbEntrada.Items.Add(50m);
        }

        private void CarregarTemas(List<Tema> temas)
        {
            cmbTemas.Items.Clear();

            foreach (Tema tema in temas)
                cmbTemas.Items.Add(tema);
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            foreach (Cliente cliente in clientes)
                cmbClientes.Items.Add(cliente);
        }
    }
}
