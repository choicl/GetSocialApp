using GetSocial.Domain.Aggregates.PostAggregate;
using Microsoft.AspNetCore.Mvc;

namespace GetSocial.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseRoute)]
    public class PostsController : Controller
    {
        [HttpGet]
        [Route(ApiRoutes.Posts.GetById)]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}
