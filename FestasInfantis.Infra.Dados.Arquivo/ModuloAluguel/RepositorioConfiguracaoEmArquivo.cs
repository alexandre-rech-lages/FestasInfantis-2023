using FestasInfantis.Dominio.ModuloAluguel;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace FestasInfantis.Infra.Dados.Arquivo.ModuloAluguel
{
    public class RepositorioConfiguracaoEmArquivo : IRepositorioConfiguracaoDesconto
    {
        private const string NOME_ARQUIVO = "Compartilhado\\Configuracoes.json";
        
        public ConfiguracaoDesconto configuracaoDesconto;       

        public RepositorioConfiguracaoEmArquivo(bool carregarDados)
        {
            if (carregarDados)
                CarregarDoArquivoJson();
        }

        public void GravarConfiguracoesDesconto(ConfiguracaoDesconto configuracaoDesconto)
        {
            this.configuracaoDesconto = configuracaoDesconto;

            JsonSerializerOptions config = ObterConfiguracoesDeSerializacao();

            string registrosJson = JsonSerializer.Serialize(this, config);

            File.WriteAllText(NOME_ARQUIVO, registrosJson);
        }

        public ConfiguracaoDesconto ObterConfiguracaoDeDesconto()
        {
            return configuracaoDesconto;
        }

        private void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoesDeSerializacao();

            if (File.Exists(NOME_ARQUIVO))
            {
                string registrosJson = File.ReadAllText(NOME_ARQUIVO);

                if (registrosJson.Length > 0)
                {
                    configuracaoDesconto = JsonSerializer.Deserialize<ConfiguracaoDesconto>(registrosJson, config);
                }
            }
            else
            {
                configuracaoDesconto = new ConfiguracaoDesconto();
            }
        }

        private static JsonSerializerOptions ObterConfiguracoesDeSerializacao()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;

            return opcoes;
        }
    }
}
