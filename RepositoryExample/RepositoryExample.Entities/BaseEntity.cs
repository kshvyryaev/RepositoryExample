using MongoDB.Bson.Serialization.Attributes;
using RepositoryExample.Base.Domain;
using RepositoryExample.Base.Identifier;

namespace RepositoryExample.Entities
{
    public abstract class BaseEntity : IEntity<ObjectIdentifier>
    {
        [BsonId]
        public ObjectIdentifier Id { get; set; }
    }
}
