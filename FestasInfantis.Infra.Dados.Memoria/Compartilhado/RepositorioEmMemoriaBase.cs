using FestasInfantis.Dominio.Compartilhado;

namespace FestasInfantis.Infra.Dados.Memoria.Compartilhado
{
    public abstract class RepositorioEmMemoriaBase<TEntidade>
            where TEntidade : EntidadeBase<TEntidade>
    {
        protected List<TEntidade> listaRegistros;
        protected int contadorRegistros = 0;

        protected RepositorioEmMemoriaBase(List<TEntidade> listaRegistros)
        {
            this.listaRegistros = listaRegistros;
            contadorRegistros = listaRegistros.Count;
        }

        public virtual void Inserir(TEntidade registro)
        {
            contadorRegistros++;

            registro.id = contadorRegistros;

            listaRegistros.Add(registro);
        }

        public virtual void Editar(int id, TEntidade registroAtualizado)
        {
            TEntidade registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Editar(TEntidade registroSelecionado, TEntidade registroAtualizado)
        {
            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }

        public virtual void Excluir(int id)
        {
            TEntidade registroSelecionado = SelecionarPorId(id);

            if (registroSelecionado != null)
                listaRegistros.Remove(registroSelecionado);
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            listaRegistros.Remove(registroSelecionado);
        }

        public virtual TEntidade SelecionarPorId(int id)
        {
            if (listaRegistros.Exists(registro => registro.id == id))
                return listaRegistros.First(registro => registro.id == id);

            return null;
        }

        public virtual List<TEntidade> SelecionarTodos()
        {
            return listaRegistros.OrderByDescending(x => x.id).ToList();
        }

        public int ObterQuantidade()
        {
            return listaRegistros.Count;
        }
    }
}
