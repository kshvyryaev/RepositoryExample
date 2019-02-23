using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using RepositoryExample.Domain.Commands.Entities;
using RepositoryExample.Domain.Services;
using RepositoryExample.Domain.Validation;
using RepositoryExample.Domain.Validation.Entities;
using RepositoryExample.Entities;
using RepositoryExample.Persistence;

namespace RepositoryExample.Ioc
{
    public static class IocConfiguration
    {
        public static void ConfigureIoc(this IServiceCollection services, IConfiguration configuration, IMapper mapper)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            services.AddTransient<IDatabaseConfiguration>(c => new Persistence.Mongo.DatabaseConfiguration(configuration));
            services.AddTransient<IRepository<Entity, ObjectId>, Persistence.Mongo.Repository<Entity, ObjectId>>();
            services.AddTransient<IEntitiesRepository<ObjectId>, Persistence.Mongo.EntitiesRepository>();

            services.AddTransient<ICommandValidator<CreateEntityCommand, Entity>, CreateEntityValidator>();
            services.AddTransient<ICommandValidator<UpdateEntityCommand, Entity>, UpdateEntityValidator>();

            services.AddTransient<IMapper>(c => mapper);

            services.AddTransient<IEntitiesService, EntitiesService>();
        }
    }
}
