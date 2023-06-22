using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestasInfantis.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }

        public abstract string ToolTipEditar { get; }

        public abstract string ToolTipExcluir { get; }

        public virtual string ToolTipFiltrar { get; }

        public virtual string ToolTipAdicionarItens { get; }

        public virtual string ToolTipConcluirAluguel { get; }

        public virtual string ToolTipVisualizarAlugueis { get; }

        public virtual string ToolTipConfigurarDescontos { get; }

            

        public virtual bool InserirHabilitado { get { return true; } }
        public virtual bool EditarHabilitado { get { return true; } }
        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool FiltrarHabilitado { get { return false; } }
        public virtual bool AdicionarItensHabilitado { get { return false; } }
        public virtual bool VisualizarAlugueisHabilitado { get { return false; } }
        public virtual bool ConcluirAluguelHabilitado { get { return false; } }
        public virtual bool ConfigurarDescontosHabilitado { get { return false; } }

        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Filtrar()
        {
        }

        public virtual void Adicionar()
        {
        }

        public virtual void ConcluirItens()
        {
        }

        public abstract UserControl ObterListagem();

        public abstract string ObterTipoCadastro();
    }
}
