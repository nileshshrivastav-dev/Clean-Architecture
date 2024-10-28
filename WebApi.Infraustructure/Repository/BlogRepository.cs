using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Entities;
using WebApi.Domain.Interface;
using WebApi.Infraustructure.Data;

namespace WebApi.Infraustructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext blogDbContext;

        public BlogRepository(BlogDbContext _blogDbContext)
        {
            blogDbContext = _blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await blogDbContext.Blogs.AddAsync(blog);
            await blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await blogDbContext.Blogs.Where(model => model.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await blogDbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id) ?? new();
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await blogDbContext.Blogs.Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Name, blog.Name)
                .SetProperty(m => m.FatherName, blog.FatherName)
                .SetProperty(m => m.Description, blog.Description)
                 .SetProperty(m => m.Author, blog.Author)
                );
        }
    }
}
