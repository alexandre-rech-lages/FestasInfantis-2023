using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;

namespace FestasInfantis.WinApp.ModuloTema
{
    public class ControladorTema : ControladorBase
    {
        private TabelaTemaControl tabelaTema;
        private readonly IRepositorioTema repositorioTema;
        private readonly IRepositorioItem repositorioItem;

        public ControladorTema(IRepositorioTema repositorioTema, IRepositorioItem repositorioItem)
        {
            this.repositorioTema = repositorioTema;
            this.repositorioItem = repositorioItem;
        }

        public override string ToolTipInserir { get { return "Inserir novo Tema"; } }

        public override string ToolTipEditar { get { return "Editar Tema existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Tema existente"; } }

        public override string ToolTipAdicionarItens { get { return "Adicionar Itens"; } }

        public override bool AdicionarItensHabilitado { get { return true; } }

        public override void Inserir()
        {
            TelaTemaForm telaTema = new TelaTemaForm(repositorioItem.SelecionarTodos());

            DialogResult opcaoEscolhida = telaTema.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Tema Tema = telaTema.ObterTema();

                repositorioTema.Inserir(Tema);
            }
            CarregarTemas();
        }

        public override void Editar()
        {
            Tema tema = ObterTemaSelecionado();

            if (tema == null)
            {
                MessageBox.Show($"Selecione um tema primeiro!",
                    "Edição de Temas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaTemaForm telaTema = new TelaTemaForm(repositorioItem.SelecionarTodos());
            telaTema.ConfigurarTela(tema);

            DialogResult opcaoEscolhida = telaTema.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Tema TemaAtualizado = telaTema.ObterTema();
                repositorioTema.Editar(TemaAtualizado.id, TemaAtualizado);
            }

            CarregarTemas();
        }


        public override void Excluir()
        {
            Tema Tema = ObterTemaSelecionado();

            if (Tema == null)
            {
                MessageBox.Show($"Selecione um tema primeiro!",
                    "Exclusão de Temas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o Tema {Tema.nome}?", "Exclusão de Temas",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTema.Excluir(Tema);
            }
            CarregarTemas();
        }

        public override void Adicionar()
        {
            Tema tema = ObterTemaSelecionado();

            if (tema == null)
            {
                MessageBox.Show($"Selecione um tema primeiro!",
                    "Adicionar Item de Tema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaSelecaoItensForm telaItens = new TelaSelecaoItensForm(repositorioItem.SelecionarTodos(), tema);

            DialogResult resultado = telaItens.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                tema.AtualizarItens(telaItens.ObterItensMarcados());

                repositorioTema.Editar(tema.id, tema);
            }
        }

        private Tema ObterTemaSelecionado()
        {
            int id = tabelaTema.ObterIdSelecionado();

            return repositorioTema.SelecionarPorId(id);
        }

        private void CarregarTemas()
        {
            List<Tema> Temas = repositorioTema.SelecionarTodos();

            tabelaTema.AtualizarRegistros(Temas);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaTema == null)
                tabelaTema = new TabelaTemaControl();

            CarregarTemas();

            return tabelaTema;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Temas";
        }
    }
}
