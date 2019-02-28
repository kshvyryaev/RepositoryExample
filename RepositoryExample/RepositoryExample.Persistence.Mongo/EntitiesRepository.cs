using RepositoryExample.Base.Identifier;
using RepositoryExample.Entities;

namespace RepositoryExample.Persistence.Mongo
{
    public class EntitiesRepository : Repository<Entity, ObjectIdentifier>, IEntitiesRepository<ObjectIdentifier>
    {
        public EntitiesRepository(IDatabaseConfiguration configuration) : base(configuration)
        {
        }
    }
}
