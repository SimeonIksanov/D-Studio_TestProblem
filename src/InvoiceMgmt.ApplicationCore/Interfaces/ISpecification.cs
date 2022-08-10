using System.Linq.Expressions;
using InvoiceMgmt.ApplicationCore.Entities;

namespace InvoiceMgmt.ApplicationCore.Interfaces
{
    public interface ISpecification<TEntity> where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>> Criteria { get; }

        int Page { get; }
        int PageSize { get; }
    }
}