using System.Text.Json.Serialization;
using System.Text.Json;
using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Dominio.ModuloTema;
using FestasInfantis.Dominio.ModuloAluguel;
using FestasInfantis.Dominio.ModuloCliente;

namespace FestasInfantis.Infra.Dados.Arquivo.Compartilhado
{
    public class ContextoDados //container
    {
        private const string NOME_ARQUIVO = "Compartilhado\\FestasInfantis.json";

        public List<Item> itens;

        public List<Tema> temas;

        public List<Aluguel> alugueis;

        public List<Cliente> clientes;

        public ContextoDados()
        {
            itens = new List<Item>();
            temas = new List<Tema>();
            alugueis = new List<Aluguel>();
            clientes = new List<Cliente>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                CarregarDoArquivoJson();
        }

        public void GravarEmArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            string registrosJson = JsonSerializer.Serialize(this, config);

            File.WriteAllText(NOME_ARQUIVO, registrosJson);
        }

        private void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            if (File.Exists(NOME_ARQUIVO))
            {
                string registrosJson = File.ReadAllText(NOME_ARQUIVO);

                if (registrosJson.Length > 0)
                {
                    ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosJson, config);

                    this.itens = ctx.itens;
                    this.temas = ctx.temas;
                    this.alugueis = ctx.alugueis;
                    this.clientes = ctx.clientes;
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}
