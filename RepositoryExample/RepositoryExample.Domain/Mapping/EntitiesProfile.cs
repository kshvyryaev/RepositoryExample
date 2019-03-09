using AutoMapper;
using RepositoryExample.Base.Identifier;
using RepositoryExample.Domain.Commands.Entities;
using RepositoryExample.Domain.Helpers;
using RepositoryExample.Domain.Responses;
using RepositoryExample.Entities;

namespace RepositoryExample.Domain.Mapping
{
    public class EntitiesProfile : Profile
    {
        public EntitiesProfile()
        {
            this.CreateMap<Entity, EntityResponse>();

            this.CreateMap<CreateEntityCommand, Entity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(command => ObjectIdentifier.GenerateNewId()));

            this.CreateMap<UpdateEntityCommand, Entity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(command => ObjectIdentifierParser.ValidateAndParse(command.Id)));
        }
    }
}
