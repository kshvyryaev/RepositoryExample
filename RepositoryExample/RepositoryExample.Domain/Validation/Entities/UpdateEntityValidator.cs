﻿using FluentValidation;
using RepositoryExample.Base.Identifier;
using RepositoryExample.Domain.Commands.Entities;
using RepositoryExample.Entities;
using RepositoryExample.Persistence;
using RepositoryExample.Persistence.Specifications;

namespace RepositoryExample.Domain.Validation.Entities
{
    public class UpdateEntityValidator : AbstractValidator<UpdateEntityCommand>, ICommandValidator<UpdateEntityCommand, Entity>
    {
        public UpdateEntityValidator(IEntitiesRepository<ObjectIdentifier> entitiesRepository)
        {
            this.RuleFor(e => e.Id)
                .NotEmpty()
                .Must((command, id) => 
                {
                    if (!ObjectIdentifier.TryParse(id, out ObjectIdentifier entityId))
                    {
                        return false;
                    }

                    var entity = entitiesRepository.Get(entityId);
                    return entity != null;
                })
                .WithMessage("Entity with such id doesn't exist");

            this.RuleFor(e => e.Name)
                .NotEmpty()
                .Must(name => entitiesRepository.Find(new FindEntityByName(name)) == null)
                .WithMessage("Entity with such name already exists");

            this.RuleFor(e => e.Description).NotEmpty();
        }

        public void ValidateAndThrowIfFailed(UpdateEntityCommand command, Entity sourceEntity = null)
        {
            this.ValidateAndThrow(command);
        }
    }
}
