using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryExample.Domain.Commands.Entities;
using RepositoryExample.Domain.Services;
using RepositoryExample.WebApi.Infrastructure;

namespace RepositoryExample.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EntitiesController : ApiControllerBase
    {
        private readonly IEntitiesService _entitiesService;

        public EntitiesController(IEntitiesService entitiesService)
        {
            _entitiesService = entitiesService ?? throw new ArgumentNullException(nameof(entitiesService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _entitiesService.GetAllAsync();
            return this.Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var entity = await _entitiesService.GetByIdAsync(id);
            return this.ResultIfNotNull(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEntityCommand createCommand)
        {
            var createdEntity = await _entitiesService.CreateAsync(createCommand);
            return this.CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEntityCommand updateCommand)
        {
            var updatedEntity = await _entitiesService.UpdateAsync(updateCommand);
            return this.ResultIfNotNull(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _entitiesService.DeleteAsync(id);
        }
    }
}