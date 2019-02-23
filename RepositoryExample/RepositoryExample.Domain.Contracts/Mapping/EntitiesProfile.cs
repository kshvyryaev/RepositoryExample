using AutoMapper;
using MongoDB.Bson;
using RepositoryExample.Domain.Commands.Entities;
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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(command => ObjectId.GenerateNewId()));

            this.CreateMap<UpdateEntityCommand, Entity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(command => ObjectId.Parse(command.Id)));
        }
    }
}
