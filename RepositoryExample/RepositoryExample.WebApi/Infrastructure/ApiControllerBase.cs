using Microsoft.AspNetCore.Mvc;

namespace RepositoryExample.WebApi.Infrastructure
{
    public class ApiControllerBase : ControllerBase
    {
        public IActionResult ResultIfNotNull<T>(T result)
            where T : class
        {
            return result == null ? this.NotFound() : (IActionResult)this.Ok(result);
        }
    }
}
