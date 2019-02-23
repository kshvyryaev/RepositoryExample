using System;
using Microsoft.Extensions.Configuration;

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
        }

        public string ConnectionString { get; }

        public string Database { get; }
    }
}
