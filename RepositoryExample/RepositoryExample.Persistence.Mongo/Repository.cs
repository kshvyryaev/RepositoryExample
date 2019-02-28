using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using RepositoryExample.Base.Domain;

namespace RepositoryExample.Persistence.Mongo
{
    public class Repository<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier>
        where TEntity : class, IEntity<TIdentifier>
    {
        public Repository(IDatabaseConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var client = new MongoClient(configuration.ConnectionString);
            this.Database = client.GetDatabase(configuration.Database);
        }

        protected IMongoDatabase Database { get; }

        protected IMongoCollection<TEntity> Collection => this.Database.GetCollection<TEntity>(typeof(TEntity).Name);

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await this.Collection.Find(e => true).ToListAsync();
        }

        public async Task<TEntity> GetAsync(TIdentifier id)
        {
            return await this.Collection.Find(e => e.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public TEntity Get(TIdentifier id)
        {
            return this.Collection.Find(e => e.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<IReadOnlyCollection<TEntity>> FindAllAsync(ISpecification<TEntity> specification)
        {
            return await this.Collection.Find(specification.Predicate).ToListAsync();
        }

        public async Task<TEntity> FindAsync(ISpecification<TEntity> specification)
        {
            return await this.Collection.Find(specification.Predicate).FirstOrDefaultAsync();
        }

        public TEntity Find(ISpecification<TEntity> specification)
        {
            return this.Collection.Find(specification.Predicate).FirstOrDefault();
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            await this.Collection.ReplaceOneAsync(e => e.Id.Equals(entity.Id), entity, new UpdateOptions
            {
                IsUpsert = true
            });

            return entity;
        }

        public async Task DeleteAsync(TIdentifier id)
        {
            await this.Collection.DeleteOneAsync(e => e.Id.Equals(id));
        }
    }
}
