using FluentValidation;
using MongoDB.Bson;
using RepositoryExample.Domain.Commands.Entities;
using RepositoryExample.Entities;
using RepositoryExample.Persistence;
using RepositoryExample.Persistence.Specifications;

namespace RepositoryExample.Domain.Validation.Entities
{
    public class CreateEntityValidator : AbstractValidator<CreateEntityCommand>, ICommandValidator<CreateEntityCommand, Entity>
    {
        public CreateEntityValidator(IEntitiesRepository<ObjectId> entitiesRepository)
        {
            this.RuleFor(e => e.Name)
                .NotEmpty()
                .Must(name => entitiesRepository.Find(new FindEntityByName(name)) == null)
                .WithMessage("Entity with this name already exists");

            this.RuleFor(e => e.Description).NotEmpty();
        }

        public void ValidateAndThrowIfFailed(CreateEntityCommand command, Entity sourceEntity = null)
        {
            this.ValidateAndThrow(command);
        }
    }
}
