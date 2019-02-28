using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using RepositoryExample.Base.Identifier;

namespace RepositoryExample.Persistence.Mongo
{
    public class ObjectIdentifierSerializer : SerializerBase<ObjectIdentifier>, IBsonSerializationProvider
    {
        public override ObjectIdentifier Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            ObjectId objectId = context.Reader.ReadObjectId();
            return new ObjectIdentifier(objectId);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, ObjectIdentifier value)
        {
            context.Writer.WriteObjectId(value.Id);
        }

        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(ObjectIdentifier))
            {
                return new ObjectIdentifierSerializer();
            }

            return null;
        }
    }
}
