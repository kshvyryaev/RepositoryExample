using System.Collections.Generic;
using System.Threading.Tasks;
using RepositoryExample.Base.Domain;
using RepositoryExample.Entities;

namespace RepositoryExample.Persistence
{
    public interface IRepository<TEntity, in TIdentifier>
        where TEntity : BaseEntity
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(TIdentifier id);

        TEntity Get(TIdentifier id);

        Task<IReadOnlyCollection<TEntity>> FindAllAsync(ISpecification<TEntity> specification);

        Task<TEntity> FindAsync(ISpecification<TEntity> specification);

        TEntity Find(ISpecification<TEntity> specification);

        Task<TEntity> SaveAsync(TEntity entity);

        Task DeleteAsync(TIdentifier id);
    }
}
