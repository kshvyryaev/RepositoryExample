using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryExample.Base.Identifier;
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

            services.AddSingleton<IDatabaseConfiguration>(c => new Persistence.Mongo.DatabaseConfiguration(configuration));
            services.AddSingleton<IEntitiesRepository<ObjectIdentifier>, Persistence.Mongo.EntitiesRepository>();

            services.AddTransient<ICommandValidator<CreateEntityCommand, Entity>, CreateEntityValidator>();
            services.AddTransient<ICommandValidator<UpdateEntityCommand, Entity>, UpdateEntityValidator>();

            services.AddSingleton<IMapper>(c => mapper);

            services.AddSingleton<IEntitiesService, EntitiesService>();
        }
    }
}
