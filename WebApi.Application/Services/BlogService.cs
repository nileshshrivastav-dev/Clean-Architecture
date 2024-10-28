using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interface;

namespace WebApi.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository blogRepository;

        public BlogService(IBlogRepository _blogRepository)
        {
            blogRepository = _blogRepository;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            return await blogRepository.CreateAsync(blog);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await blogRepository.DeleteAsync(id);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await blogRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await blogRepository.UpdateAsync(id,blog);
        }
    }
}
