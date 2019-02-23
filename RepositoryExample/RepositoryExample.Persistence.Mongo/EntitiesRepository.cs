using MongoDB.Bson;
using RepositoryExample.Entities;

namespace RepositoryExample.Persistence.Mongo
{
    public class EntitiesRepository : Repository<Entity, ObjectId>, IEntitiesRepository<ObjectId>
    {
        public EntitiesRepository(IDatabaseConfiguration configuration) : base(configuration)
        {
        }
    }
}
