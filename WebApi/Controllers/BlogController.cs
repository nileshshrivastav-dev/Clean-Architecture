using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebApi.Application.Services;
using WebApi.Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService _blogService)
        {
            blogService = _blogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Blogs = await blogService.GetAllAsync();
            return Ok(Blogs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var createdBlog= await blogService.CreateAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id=createdBlog.Id},createdBlog);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            int existingBlog = await blogService.UpdateAsync(id, blog);
            if (existingBlog == 0)
            {
                return BadRequest();
            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int blog = await blogService.DeleteAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
