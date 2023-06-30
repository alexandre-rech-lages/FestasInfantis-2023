using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private TabelaAluguelControl tabelaAlugueis;
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioTema repositorioTema;
        private IRepositorioConfiguracaoDesconto repositorioDesconto;

        public ControladorAluguel(
            IRepositorioAluguel repositorioAluguel, 
            IRepositorioCliente repositorioCliente,
            IRepositorioTema repositorioTema,
            IRepositorioConfiguracaoDesconto repositorioDesconto
            )
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioCliente = repositorioCliente;
            this.repositorioTema = repositorioTema;
            this.repositorioDesconto = repositorioDesconto;
        }

        public override string ToolTipInserir { get { return "Inserir novo Aluguel"; } }

        public override string ToolTipEditar { get { return "Editar Aluguel existente"; } }
            
        public override string ToolTipExcluir { get { return "Excluir Aluguel existente"; } }

        public override string ToolTipFiltrar { get { return "Filtrar Alugueis"; } }
        
        public override string ToolTipConcluirAluguel { get { return "Concluir Aluguel"; } }

        public override string ToolTipConfigurarDescontos { get { return "Configurar Descontos de Aluguel"; } }

        public override bool FiltrarHabilitado { get { return true; } }

        public override bool ConcluirAluguelHabilitado { get { return true; } }

        public override bool ConfigurarDescontosHabilitado { get { return true; } }

        public override void Inserir()
        {

            TelaAluguelForm telaAluguel = 
                new TelaAluguelForm(
                    repositorioDesconto.ObterConfiguracaoDeDesconto(),
                    repositorioCliente.SelecionarTodos(carregarAlugueis: true),
                    repositorioTema.SelecionarTodos());

            telaAluguel.ConfigurarTela(new Aluguel());

            DialogResult opcaoEscolhida = telaAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguel = telaAluguel.ObterAluguel();

                repositorioAluguel.Inserir(aluguel);
                
                CarregarAlugueis();
            }
        }

        public override void Editar()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            else if (aluguel.PagamentoConcluido)
            {
                MessageBox.Show($"Não é possível editar os dados de um aluguel concluído.",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaAluguelForm telaAluguel =
                new TelaAluguelForm(
                    repositorioDesconto.ObterConfiguracaoDeDesconto(),
                    repositorioCliente.SelecionarTodos(carregarAlugueis: true),
                    repositorioTema.SelecionarTodos());

            telaAluguel.ConfigurarTela(aluguel);

            DialogResult opcaoEscolhida = telaAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguelAtualizado = telaAluguel.ObterAluguel();

                repositorioAluguel.Editar(aluguelAtualizado.id, aluguelAtualizado);
            }

            CarregarAlugueis();
        }

        public override void Excluir()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!",
                    "Exclusão de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            else if (aluguel.PagamentoConcluido == false)
            {
                MessageBox.Show($"Não é possível excluir os dados de um aluguel em aberto.",
                    "Exclusão de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o aluguel {aluguel.id}?", "Exclusão de Aluguéis",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioAluguel.Excluir(aluguel);
                CarregarAlugueis();
            }
        }

        public override void Filtrar()
        {
            TelaFiltroAluguelForm telaFiltroAluguel = new TelaFiltroAluguelForm();

            DialogResult opcaoEscolhida = telaFiltroAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                List<Aluguel> alugueis;

                StatusAluguelEnum status = telaFiltroAluguel.ObterFiltroAluguel();

                switch (status)
                {
                    case StatusAluguelEnum.Pendentes:
                        alugueis = repositorioAluguel.SelecionarPendentes();
                        break;

                    case StatusAluguelEnum.Concluidos:
                        alugueis = repositorioAluguel.SelecionarConcluidos();
                        break;

                    default:
                        alugueis = repositorioAluguel.SelecionarTodos();
                        break;
                }

                CarregarAlugueis(alugueis);
            }
        }

        public void ConcluirAluguel()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!",
                    "Conclusão de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            else if (aluguel.PagamentoConcluido)
            {
                MessageBox.Show($"O aluguel já está concluído!",
                    "Conclusão de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaConclusaoAluguelForm telaConclusaoAluguel =
                new TelaConclusaoAluguelForm(aluguel, repositorioDesconto.ObterConfiguracaoDeDesconto());

            DialogResult opcaoEscolhida = telaConclusaoAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                aluguel.Concluir();

                repositorioAluguel.Editar(aluguel.id, aluguel);
            }

            CarregarAlugueis();
        }

        public void ConfigurarDescontos()
        {
            ConfiguracaoDesconto configuracao = repositorioDesconto.ObterConfiguracaoDeDesconto();

            TelaConfiguracaoDescontoForm telaConfiguracao = new TelaConfiguracaoDescontoForm(configuracao);

            DialogResult opcaoEscolhida = telaConfiguracao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                ConfiguracaoDesconto novaConfiguracao = telaConfiguracao.ObterConfiguracaoDesconto();

                repositorioDesconto.GravarConfiguracoesDesconto(novaConfiguracao);
            }
        }

        public override UserControl ObterListagem()
        {
            if (tabelaAlugueis == null)
                tabelaAlugueis = new TabelaAluguelControl();

            CarregarAlugueis();

            return tabelaAlugueis;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Aluguéis";
        }

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAlugueis.AtualizarRegistros(alugueis);
        }

        private void CarregarAlugueis(List<Aluguel> alugueis)
        {
            tabelaAlugueis.AtualizarRegistros(alugueis);
        }

        private Aluguel ObterAluguelSelecionado()
        {
            int id = tabelaAlugueis.ObterIdSelecionado();

            return repositorioAluguel.SelecionarPorId(id);
        }
    }
}