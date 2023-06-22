using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;

using FestasInfantis.Infra.Dados.Arquivo.Compartilhado;
using FestasInfantis.Infra.Dados.Arquivo.ModuleTema;
using FestasInfantis.Infra.Dados.Arquivo.ModuloAluguel;
using FestasInfantis.Infra.Dados.Arquivo.ModuloItem;

using FestasInfantis.Infra.Dados.Sql.ModuloCliente;

using FestasInfantis.WinApp.ModuloAluguel;
using FestasInfantis.WinApp.ModuloCliente;
using FestasInfantis.WinApp.ModuloItem;
using FestasInfantis.WinApp.ModuloTema;

namespace FestasInfantis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        private static ContextoDados contextoDados = new ContextoDados(carregarDados: true);

        private IRepositorioCliente repositorioCliente = new RepositorioClienteSql();

        private IRepositorioConfiguracaoDesconto repositorioDesconto = new RepositorioConfiguracaoEmArquivo(carregarDados: true);        

        private IRepositorioItem repositorioItem = new RepositorioItemEmArquivo(contextoDados);

        private IRepositorioTema repositorioTema = new RepositorioTemaEmArquivo(contextoDados);

        private IRepositorioAluguel repositorioAluguel = new RepositorioAluguelEmArquivo(contextoDados);

        private static TelaPrincipalForm telaPrincipal;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            telaPrincipal = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        public static TelaPrincipalForm Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipalForm();

                return telaPrincipal;
            }
        }

        private void clientesMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorCliente(repositorioCliente);

            ConfigurarTelaPrincipal(controlador);
        }

        private void itensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorItem(repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void temasMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTema(repositorioTema, repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void alugueisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorAluguel(
                repositorioAluguel,
                repositorioCliente,
                repositorioTema,
                repositorioDesconto);

            ConfigurarTelaPrincipal(controlador);
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            labelTipoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarBarraFerramentas(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarBarraFerramentas(ControladorBase controlador)
        {
            barraFerramentas.Enabled = true;

            ConfigurarToolTips(controlador);

            ConfigurarEstados(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
            btnAdicionarItens.ToolTipText = controlador.ToolTipAdicionarItens;
            btnVisualizarAlugueisCliente.ToolTipText = controlador.ToolTipVisualizarAlugueis;
            btnConcluirAluguel.ToolTipText = controlador.ToolTipConcluirAluguel;
            btnConfigurarDescontos.ToolTipText = controlador.ToolTipConfigurarDescontos;
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnFiltrar.Enabled = controlador.FiltrarHabilitado;
            btnAdicionarItens.Enabled = controlador.AdicionarItensHabilitado;
            btnVisualizarAlugueisCliente.Enabled = controlador.VisualizarAlugueisHabilitado;
            btnConcluirAluguel.Enabled = controlador.ConcluirAluguelHabilitado;
            btnConfigurarDescontos.Enabled = controlador.ConfigurarDescontosHabilitado;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void btnConcluirAluguel_Click(object sender, EventArgs e)
        {
            (controlador as ControladorAluguel)!.ConcluirAluguel();
        }

        private void btnVisualizarAlugueis_Click(object sender, EventArgs e)
        {
            (controlador as ControladorCliente)!.VisualizarAlugueis();
        }

        private void btnConfigurarDescontos_Click(object sender, EventArgs e)
        {
            (controlador as ControladorAluguel)!.ConfigurarDescontos();
        }

        private static List<Item> ConfigurarItens()
        {
            List<Item> itens = new List<Item>();

            Item item = new Item(1, "Mesa Grande x50", 150m);
            Item item2 = new Item(2, "Chapéu do Mickey x25", 50m);

            itens.Add(item);
            itens.Add(item2);

            return itens;
        }

        private static List<Tema> ConfigurarTemas()
        {
            List<Item> itens = new List<Item>();

            Item item = new Item(1, "Mesa Grande x50", 150m);
            Item item2 = new Item(2, "Chapéu do Mickey x25", 50m);

            itens.Add(item);
            itens.Add(item2);

            List<Tema> temas = new List<Tema>();

            Tema tema = new Tema(1, "Festa de Aniversário", itens);

            temas.Add(tema);

            return temas;
        }

        private static List<Cliente> ConfigurarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            Cliente cliente = new Cliente(1, "Tiago Santini", "(49) 98505-6251");
            Cliente cliente2 = new Cliente(2, "Alexandre Rech", "(49) 99225-8850");
            clientes.Add(cliente);
            clientes.Add(cliente2);

            return clientes;
        }

        private static List<Aluguel> ConfigurarAlugueis()
        {
            List<Aluguel> alugueis = new List<Aluguel>();

            Endereco endereco = new Endereco("Marechal Deodoro", "Centro", "Lages", "SC", "40");
            Festa festa = new Festa(endereco, DateTime.Now, TimeSpan.Parse("1200"), TimeSpan.Parse("1800"));

            Cliente cliente = new Cliente(1, "Tiago Santini", "(49) 98505-6251");

            List<Item> itens = new List<Item>();

            Item item = new Item(1, "Mesa Grande x50", 150m);
            Item item2 = new Item(2, "Chapéu do Mickey x25", 50m);

            itens.Add(item);
            itens.Add(item2);

            Tema tema = new Tema(1, "Festa de Aniversário", itens);

            Aluguel aluguel = new Aluguel(1, cliente, festa, tema, 40, 0.0m);

            alugueis.Add(aluguel);

            return alugueis;
        }
    }
}