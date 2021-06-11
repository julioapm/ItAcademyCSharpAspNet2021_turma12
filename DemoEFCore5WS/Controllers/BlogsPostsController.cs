using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoEFCore5WS.Data;
using DemoEFCore5WS.Models;
using DemoEFCore5WS.Dtos;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BlogDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BlogDTO>> GetPorId(int id)
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
                var blogDto = new BlogDTO{
                    Id = blog.Id,
                    Nome = blog.Nome,
                    Posts = blog.Posts.Select(p => new PostDTO{
                        Id = p.Id,
                        Titulo = p.Titulo,
                        Data = p.Data
                    }).ToList(),
                    UltimaAtualizacao = blog.Posts.Max(p => p.Data)
                };
                return blogDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Falha de consulta ao id {id}");
                throw;
            }
        }
    
        [HttpDelete("blog/{id}")]
        //DELETE blogsposts/blog/{id}
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePorId(int id)
        {
            try
            {
                var blog = await _blogs.RemoverPorId(id);
                if (blog == null)
                {
                    _logger.LogDebug($"Não encontrou blog id {id}");
                    return NotFound();
                }
                _logger.LogDebug($"Removeu blog id {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Falha de remoção do id {id}");
                throw;
            }
        }

        [HttpPost("blog/{id}/post")]
        //POST blogsposts/blog/{id}/post
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostarMensagem(int id, [FromBody] string titulo)
        {
            _logger.LogInformation($"Titulo = {titulo}");
            try
            {
                var blog = await _blogs.BuscarPorId(id);
                if (blog == null)
                {
                    _logger.LogDebug($"Não encontrou blog id {id}");
                    return BadRequest();
                }
                var post = new Post{
                    Titulo = titulo,
                    Data = DateTime.Now
                };
                await _blogs.AdicionarPost(id, post);
                _logger.LogDebug($"Alterou blog id {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Falha de alteração do id {id}");
                throw;
            }
        }
    }
}
