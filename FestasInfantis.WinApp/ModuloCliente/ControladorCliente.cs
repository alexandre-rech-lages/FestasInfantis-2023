using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestasInfantis.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private TabelaClienteControl tabelaCliente;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioAluguel repositorioAluguel;

        public ControladorCliente(IRepositorioCliente repositorioCliente, IRepositorioAluguel repositorioAluguel)
        {
            this.repositorioCliente = repositorioCliente;
            this.repositorioAluguel = repositorioAluguel;
        }

        public override string ToolTipInserir { get { return "Inserir novo Cliente"; } }

        public override string ToolTipEditar { get { return "Editar Cliente existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Cliente existente"; } }
        public override string ToolTipVisualizarAlugueis { get { return "Visualizar Aluguéis do Cliente"; } }

        public override bool VisualizarAlugueisHabilitado { get { return true; } }

        public void VisualizarAlugueis()
        {
            Cliente Cliente = ObterClienteSelecionado();

            if (Cliente == null)
            {
                MessageBox.Show($"Selecione um cliente primeiro!",
                    "Visualização de Alguéis do Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaAlugueisClienteForm telaCliente = new TelaAlugueisClienteForm();
            telaCliente.ConfigurarTela(Cliente);

            telaCliente.ShowDialog();
        }

        public override void Inserir()
        {
            TelaClienteForm telaCliente = new TelaClienteForm();

            DialogResult opcaoEscolhida = telaCliente.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Cliente cliente = telaCliente.ObterCliente();

                repositorioCliente.Inserir(cliente);
            }
            CarregarClientes();
        }

        public override void Editar()
        {
            Cliente Cliente = ObterClienteSelecionado();

            if (Cliente == null)
            {
                MessageBox.Show($"Selecione um cliente primeiro!",
                    "Edição de Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaClienteForm telaCliente = new TelaClienteForm();
            telaCliente.ConfigurarTela(Cliente);

            DialogResult opcaoEscolhida = telaCliente.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Cliente clienteAtualizado = telaCliente.ObterCliente();
                repositorioCliente.Editar(clienteAtualizado.id, clienteAtualizado);
            }

            CarregarClientes();
        }

        public override void Excluir()
        {
            Cliente cliente = ObterClienteSelecionado();

            if (cliente == null)
            {
                MessageBox.Show($"Selecione um cliente primeiro!",
                    "Exclusão de Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o cliente {cliente.nome}?", "Exclusão de Clientes",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioCliente.Excluir(cliente);
            }

            CarregarClientes();
        }

        private Cliente ObterClienteSelecionado()
        {
            int id = tabelaCliente.ObterIdSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }

        private void CarregarClientes()
        {
            List<Cliente> Clientes = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(Clientes);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClienteControl();

            CarregarClientes();

            return tabelaCliente;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Clientes";
        }
    }
}
