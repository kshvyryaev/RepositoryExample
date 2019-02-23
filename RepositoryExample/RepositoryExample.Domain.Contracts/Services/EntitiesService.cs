using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using RepositoryExample.Domain.Commands.Entities;
using RepositoryExample.Domain.Helpers;
using RepositoryExample.Domain.Responses;
using RepositoryExample.Domain.Validation;
using RepositoryExample.Entities;
using RepositoryExample.Persistence;

namespace RepositoryExample.Domain.Services
{
    public class EntitiesService : IEntitiesService
    {
        private readonly IEntitiesRepository<ObjectId> _entitiesRepository;
        private readonly ICommandValidator<CreateEntityCommand, Entity> _createCommandValidator;
        private readonly ICommandValidator<UpdateEntityCommand, Entity> _updateCommandValidator;
        private readonly IMapper _mapper;

        public EntitiesService(
            IEntitiesRepository<ObjectId> entitiesRepository,
            ICommandValidator<CreateEntityCommand, Entity> createCommandValidator,
            ICommandValidator<UpdateEntityCommand, Entity> updateCommandValidator,
            IMapper mapper)
        {
            _entitiesRepository = entitiesRepository ?? throw new ArgumentNullException(nameof(entitiesRepository));
            _createCommandValidator = createCommandValidator ?? throw new ArgumentNullException(nameof(createCommandValidator));
            _updateCommandValidator = updateCommandValidator ?? throw new ArgumentNullException(nameof(updateCommandValidator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyCollection<EntityResponse>> GetAllAsync()
        {
            var entities = await _entitiesRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<EntityResponse>>(entities);
        }

        public async Task<EntityResponse> GetByIdAsync(string id)
        {
            var entityId = ObjectIdParser.ValidateAndParse(id);
            var entity = await _entitiesRepository.GetAsync(entityId);

            if (entity == null)
            {
                return null;
            }

            return _mapper.Map<Entity, EntityResponse>(entity);
        }

        public async Task<EntityResponse> CreateAsync(CreateEntityCommand createCommand)
        {
            _createCommandValidator.ValidateAndThrowIfFailed(createCommand);

            var entity = _mapper.Map<CreateEntityCommand, Entity>(createCommand);
            var createdEntiy = await _entitiesRepository.SaveAsync(entity);

            return _mapper.Map<Entity, EntityResponse>(createdEntiy);
        }

        public async Task<EntityResponse> UpdateAsync(UpdateEntityCommand updateCommand)
        {
            var entityId = ObjectIdParser.ValidateAndParse(updateCommand.Id);
            var existingEntity = await _entitiesRepository.GetAsync(entityId);

            if (existingEntity == null)
            {
                return null;
            }

            _updateCommandValidator.ValidateAndThrowIfFailed(updateCommand);

            var entity = _mapper.Map<UpdateEntityCommand, Entity>(updateCommand);
            var updatedEntity = await _entitiesRepository.SaveAsync(entity);

            return _mapper.Map<Entity, EntityResponse>(updatedEntity);
        }

        public async Task DeleteAsync(string id)
        {
            var entityId = ObjectIdParser.ValidateAndParse(id);
            await _entitiesRepository.DeleteAsync(entityId);
        }
    }
}
