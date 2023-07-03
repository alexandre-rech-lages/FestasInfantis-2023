using FestasInfantis.Dominio.ModuloItem;
using FestasInfantis.Infra.Dados.Sql.Compartilhado;
using Microsoft.Data.SqlClient;

namespace FestasInfantis.Infra.Dados.Sql.ModuloItem
{
    public class RepositorioItemEmSql : RepositorioEmSqlBase<Item, MapeadorItem>, IRepositorioItem
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBITEM]
                (
                    [DESCRICAO]
                    ,[VALOR]
                )
                VALUES
                (
                    @DESCRICAO
                    ,@VALOR
                )

            SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
          @"UPDATE [TBITEM]
                SET 
                    [DESCRICAO] = @DESCRICAO
                   ,[VALOR] = @VALOR

	            WHERE 
		            [ID] = @ID";

        protected override string sqlExcluir =>
          @"DELETE FROM [TBITEM]
	            WHERE 
		            [ID] = @ID";

        protected override string sqlSelecionarPorId =>
           @"SELECT 
                [ID]            ITEM_ID
	           ,[DESCRICAO]     ITEM_DESCRICAO
	           ,[VALOR]         ITEM_VALOR

            FROM 
	            [TBITEM] 
            WHERE 
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
          @"SELECT
                [ID]            ITEM_ID
	           ,[DESCRICAO]     ITEM_DESCRICAO
	           ,[VALOR]         ITEM_VALOR
            FROM 
	            [TBITEM]";

    }
}
