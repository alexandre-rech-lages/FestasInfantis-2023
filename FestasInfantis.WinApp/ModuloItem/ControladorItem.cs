using FestasInfantis.Dominio.ModuloItem;

namespace FestasInfantis.WinApp.ModuloItem
{
    public class ControladorItem : ControladorBase
    {
        private TabelaItemControl tabelaItem;
        private readonly IRepositorioItem repositorioItem;

        public ControladorItem(IRepositorioItem repositorioItem)
        {
            this.repositorioItem = repositorioItem;
        }

        public override string ToolTipInserir { get { return "Inserir novo Item"; } }

        public override string ToolTipEditar { get { return "Editar Item existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Item existente"; } }

        public override void Inserir()
        {
            TelaItemForm telaItem = new TelaItemForm();

            DialogResult opcaoEscolhida = telaItem.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Item Item = telaItem.ObterItem();

                repositorioItem.Inserir(Item);
            }
            CarregarItems();
        }

        public override void Editar()
        {
            Item Item = ObterItemSelecionado();

            if (Item == null)
            {
                MessageBox.Show($"Selecione um item primeiro!",
                    "Edição de Itens",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaItemForm telaItem = new TelaItemForm();
            telaItem.ConfigurarTela(Item);

            DialogResult opcaoEscolhida = telaItem.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Item ItemAtualizado = telaItem.ObterItem();
                repositorioItem.Editar(ItemAtualizado.id, ItemAtualizado);
            }

            CarregarItems();
        }

        private Item ObterItemSelecionado()
        {
            int id = tabelaItem.ObterIdSelecionado();

            return repositorioItem.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Item Item = ObterItemSelecionado();

            if (Item == null)
            {
                MessageBox.Show($"Selecione um item primeiro!",
                    "Exclusão de Itens",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o Item {Item.descricao}?", "Exclusão de Items",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioItem.Excluir(Item);
            }
            CarregarItems();
        }

        private void CarregarItems()
        {
            List<Item> Items = repositorioItem.SelecionarTodos();

            tabelaItem.AtualizarRegistros(Items);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaItem == null)
                tabelaItem = new TabelaItemControl();

            CarregarItems();

            return tabelaItem;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Itens";
        }
    }
}
