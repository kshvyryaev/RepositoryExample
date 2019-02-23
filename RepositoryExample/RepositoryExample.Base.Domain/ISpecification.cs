using System;
using System.Linq.Expressions;
using RepositoryExample.Entities;

namespace RepositoryExample.Base.Domain
{
    public interface ISpecification<TEntity>
        where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>> Predicate { get; }
    }
}
