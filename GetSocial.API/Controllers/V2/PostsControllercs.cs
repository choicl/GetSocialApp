using GetSocial.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetSocial.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostsController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var post = new Post() { Id = id, Text = "Hello,universe" };
            return Ok(post);
        }
    }
}
