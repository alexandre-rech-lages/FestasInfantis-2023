namespace FestasInfantis.Infra.Dados.Arquivo.Compartilhado
{
    public abstract class RepositorioEmArquivoBase<T> where T : EntidadeBase<T>
    {
        protected ContextoDados contextoDados;
        private int contador;

        public RepositorioEmArquivoBase(ContextoDados contexto)
        {
            contextoDados = contexto;

            AtualizarContador();
        }

        protected abstract List<T> ObterRegistros();

        public void Inserir(T novoRegistro)
        {
            List<T> registros = ObterRegistros();

            contador++;
            novoRegistro.id = contador;
            registros.Add(novoRegistro);

            contextoDados.GravarEmArquivoJson();
        }

        public void Editar(int id, T registroAtualizado)
        {
            T registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);

            contextoDados.GravarEmArquivoJson();
        }

        public void Excluir(T registroSelecionado)
        {
            List<T> registros = ObterRegistros();

            registros.Remove(registroSelecionado);

            contextoDados.GravarEmArquivoJson();
        }

        public T SelecionarPorId(int id)
        {
            List<T> registros = ObterRegistros();

            return registros.FirstOrDefault(x => x.id == id);
        }

        public List<T> SelecionarTodos()
        {
            return ObterRegistros();
        }

        private void AtualizarContador()
        {
            if (ObterRegistros().Count > 0)
                contador = ObterRegistros().Max(x => x.id);
        }
    }
}
