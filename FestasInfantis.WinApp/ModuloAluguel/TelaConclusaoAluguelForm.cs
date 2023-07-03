using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaConclusaoAluguelForm : Form
    {
        private Aluguel aluguelSelecionado;
        private ConfiguracaoDesconto configuracaoDesconto;

        public TelaConclusaoAluguelForm(Aluguel aluguelSelecionado, ConfiguracaoDesconto configuracaoDesconto)
        {
            InitializeComponent();

            this.ConfigurarDialog();
            this.aluguelSelecionado = aluguelSelecionado;
            this.configuracaoDesconto = configuracaoDesconto;

            ConfigurarComboBoxes();
            ConfigurarTela();
        }

        private void ConfigurarTela()
        {
            txtId.Text = aluguelSelecionado.id.ToString();

            txtDataFesta.Text = aluguelSelecionado.Festa.Data.ToString();

            txtHorarioInicio.Text = aluguelSelecionado.Festa.HorarioInicio.ToString();
            txtHorarioTermino.Text = aluguelSelecionado.Festa.HorarioTermino.ToString();

            txtCidade.Text = aluguelSelecionado.Festa.Endereco.Cidade;
            txtEstado.Text = aluguelSelecionado.Festa.Endereco.Estado;
            txtRua.Text = aluguelSelecionado.Festa.Endereco.Rua;
            txtBairro.Text = aluguelSelecionado.Festa.Endereco.Bairro;
            txtNumero.Text = aluguelSelecionado.Festa.Endereco.Numero;

            cmbClientes.SelectedItem = aluguelSelecionado.Cliente;

            cmbTemas.SelectedItem = aluguelSelecionado.Tema;

            cmbEntrada.SelectedItem = aluguelSelecionado.PorcentagemSinal;
        }

        private void ConfigurarComboBoxes()
        {
            cmbClientes.Items.Clear();
            cmbClientes.Items.Add(aluguelSelecionado.Cliente);

            cmbTemas.Items.Clear();
            cmbTemas.Items.Add(aluguelSelecionado.Tema);

            cmbEntrada.Items.Add(40m);
            cmbEntrada.Items.Add(50m);
            cmbEntrada.SelectedIndex = 0;
        }
       

        private void AtualizarPorcentagemDesconto(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = aluguelSelecionado.Cliente;

            decimal porcentagemDesconto = clienteSelecionado.CalcularDesconto(configuracaoDesconto);

            txtPorcentagemDesconto.Text = porcentagemDesconto.ToString();
        }

        private void AtualizarValorTotal(object sender, EventArgs e)
        {
            Tema temaSelecionado = aluguelSelecionado.Tema;

            decimal valorTotal = temaSelecionado.Valor;

            txtValorTema.Text = valorTotal.ToString();
        }

        private void AtualizarPorcentagemEntrada(object sender, EventArgs e)
        {
            Tema temaSelecionado = aluguelSelecionado.Tema;

        }
    }
}
