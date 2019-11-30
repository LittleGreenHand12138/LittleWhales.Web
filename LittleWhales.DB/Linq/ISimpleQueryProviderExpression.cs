using LittleWhales.DB.Expressions;

namespace LittleWhales.DB.Linq
{
    public interface ISimpleQueryProviderExpression<TModel>
    {
        SqlExpression<TModel> AtlasSqlExpression { get; }
    }
}