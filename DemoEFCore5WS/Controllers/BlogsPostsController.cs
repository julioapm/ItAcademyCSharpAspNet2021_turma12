using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoEFCore5WS.Data;
using DemoEFCore5WS.Models;
using Microsoft.AspNetCore.Http;

namespace DemoEFCore5WS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsPostsController : ControllerBase
    {
        private readonly BlogsRepository _blogs;
        private readonly ILogger<BlogsPostsController> _logger;

        public BlogsPostsController(ILogger<BlogsPostsController> logger, BlogsRepository blogs)
        {
            _logger = logger;
            _blogs = blogs;
        }

        [HttpGet("blog/{id}")]
        //GET blogsposts/blog/{id}
        [ProducesResponseType(200, Type = typeof(Blog))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Blog>> GetPorId(int id)
        {
            try
            {
                var blog = await _blogs.BuscarPorId(id);
                if (blog == null)
                {
                    _logger.LogDebug($"Não encontrou blog id {id}");
                    return NotFound();
                }
                _logger.LogDebug($"Encontrou blog id {id}");
                return blog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Falha de consulta ao id {id}");
                throw;
            }
        }
    }
}
