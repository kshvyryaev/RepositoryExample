using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;

namespace RepositoryExample.Persistence.Mongo
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public DatabaseConfiguration(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.ConnectionString = configuration["Mongo:ConnectionString"];
            this.Database = configuration["Mongo:Database"];

            BsonSerializer.RegisterSerializationProvider(new ObjectIdentifierSerializer());
        }

        public string ConnectionString { get; }

        public string Database { get; }
    }
}
