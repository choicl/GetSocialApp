﻿using GetSocial.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetSocial.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostsController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var post = new Post() { Id = id, Text = "Hello,world" };
            return Ok(post);
        }
    }
}
