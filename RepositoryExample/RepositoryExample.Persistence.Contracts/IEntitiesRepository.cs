using RepositoryExample.Entities;

namespace RepositoryExample.Persistence
{
    public interface IEntitiesRepository<in TIdentifier> : IRepository<Entity, TIdentifier>
    {
    }
}
