using System.Linq.Expressions;
using InvoiceMgmt.ApplicationCore.Entities;
using InvoiceMgmt.ApplicationCore.Interfaces;

namespace InvoiceMgmt.ApplicationCore.Specifications;

public abstract class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
{
    public BaseSpecification(Expression<Func<TEntity, bool>> criteria = null)
    {
        Criteria = criteria;
    }

    public Expression<Func<TEntity, bool>> Criteria { get; protected set; }

    public int Page { get; protected set; } = 1;

    public int PageSize { get; protected set; } = 10;
}
