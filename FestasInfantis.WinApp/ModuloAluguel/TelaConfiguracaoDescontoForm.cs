using FestasInfantis.Dominio.ModuloAluguel;

namespace FestasInfantis.WinApp
{
    public partial class TelaConfiguracaoDescontoForm : Form
    {
        public TelaConfiguracaoDescontoForm(ConfiguracaoDesconto config)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            ConfigurarTela(config);
        }

        private void ConfigurarTela(ConfiguracaoDesconto config)
        {
            txtPorcentagemAluguel.Value = config.PorcentagemDesconto;
            txtPorcentagemMaxima.Value = config.PorcentagemMaxima;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ConfiguracaoDesconto config = ObterConfiguracaoDesconto();

            string[] erros = config.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
            else
                TelaPrincipalForm.Instancia.AtualizarRodape("Configurações de Desconto salvas com sucesso!");
        }

        public ConfiguracaoDesconto ObterConfiguracaoDesconto()
        {
            decimal porcentagemDesconto = Convert.ToDecimal(txtPorcentagemAluguel.Text);
            decimal porcentagemMaxima = Convert.ToDecimal(txtPorcentagemMaxima.Text);

            return new ConfiguracaoDesconto(porcentagemDesconto, porcentagemMaxima);
        }
    }
}
