using System.Collections.Generic;
using System.Threading.Tasks;
using RepositoryExample.Domain.Commands.Entities;
using RepositoryExample.Domain.Responses;

namespace RepositoryExample.Domain.Services
{
    public interface IEntitiesService
    {
        Task<IReadOnlyCollection<EntityResponse>> GetAllAsync();

        Task<EntityResponse> GetByIdAsync(string id);

        Task<EntityResponse> CreateAsync(CreateEntityCommand createCommand);

        Task<EntityResponse> UpdateAsync(UpdateEntityCommand updateCommand);

        Task DeleteAsync(string id);
    }
}
