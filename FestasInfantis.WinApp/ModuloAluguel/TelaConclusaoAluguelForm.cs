using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaConclusaoAluguelForm : Form
    {
        private ConfiguracaoDesconto configuracaoDesconto;

        public TelaConclusaoAluguelForm(Aluguel aluguel, ConfiguracaoDesconto configuracaoDesconto)
        {
            InitializeComponent();

            this.ConfigurarDialog();
            this.configuracaoDesconto = configuracaoDesconto;

            ConfigurarComboBoxes(aluguel);
            ConfigurarTela(aluguel);
        }

        public Aluguel ObterAluguel()
        {
            int id = Convert.ToInt32(txtId.Text);

            DateTime data = txtDataFesta.Value;

            TimeSpan horarioInicio = TimeSpan.Parse(txtHorarioInicio.Text);
            TimeSpan horarioTermino = TimeSpan.Parse(txtHorarioTermino.Text);

            Festa festa = new Festa(ObterDadosEndereco(), data, horarioInicio, horarioTermino);

            Cliente cliente = (Cliente)cmbClientes.SelectedItem;

            Tema tema = (Tema)cmbTemas.SelectedItem;

            decimal porcentagemEntrada = Convert.ToDecimal(cmbEntrada.SelectedItem);

            decimal porcentagemDesconto = Convert.ToDecimal(txtPorcentagemDesconto.Text);

            Aluguel aluguel = new Aluguel(cliente, festa, tema, porcentagemEntrada, porcentagemDesconto);

            if (id > 0)
                aluguel.id = id;

            return aluguel;
        }

        private void ConfigurarTela(Aluguel aluguel)
        {
            txtId.Text = aluguel.id.ToString();

            txtDataFesta.Text = aluguel.Festa.Data.ToString();

            txtHorarioInicio.Text = aluguel.Festa.HorarioInicio.ToString();
            txtHorarioTermino.Text = aluguel.Festa.HorarioTermino.ToString();

            txtCidade.Text = aluguel.Festa.Endereco.Cidade;
            txtEstado.Text = aluguel.Festa.Endereco.Estado;
            txtRua.Text = aluguel.Festa.Endereco.Rua;
            txtBairro.Text = aluguel.Festa.Endereco.Bairro;
            txtNumero.Text = aluguel.Festa.Endereco.Numero;

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


        private void ConfigurarComboBoxes(Aluguel aluguel)
        {
            cmbClientes.Items.Clear();
            cmbClientes.Items.Add(aluguel.Cliente);

            cmbTemas.Items.Clear();
            cmbTemas.Items.Add(aluguel.Tema);

            cmbEntrada.Items.Add(40m);
            cmbEntrada.Items.Add(50m);
            cmbEntrada.SelectedIndex = 0;
        }

        private void AtualizarTabelaValores()
        {
            txtValorPendente.Text = ObterAluguel().CalcularValorPendente().ToString();
            txtValorSinal.Text = ObterAluguel().CalcularValorSinal().ToString();
            txtValorDesconto.Text = ObterAluguel().CalcularValorDesconto().ToString();
        }

        private void AtualizarPorcentagemDesconto(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)cmbClientes.SelectedItem;

            decimal porcentagemDesconto = clienteSelecionado.CalcularDesconto(configuracaoDesconto);

            txtPorcentagemDesconto.Text = porcentagemDesconto.ToString();
        }

        private void AtualizarValorTotal(object sender, EventArgs e)
        {
            Tema temaSelecionado = (Tema)cmbTemas.SelectedItem;

            decimal valorTotal = temaSelecionado.CalcularValor();

            txtValorTema.Text = valorTotal.ToString();

            AtualizarTabelaValores();
        }

        private void AtualizarPorcentagemEntrada(object sender, EventArgs e)
        {
            Tema temaSelecionado = (Tema)cmbTemas.SelectedItem;

            if (temaSelecionado != null)
                AtualizarTabelaValores();
        }
    }
}
