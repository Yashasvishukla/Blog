using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DataContext _dbContext;
        public BlogRepository(DataContext dbContext)
        {
            _dbContext = dbContext;

        }
        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public async Task<Blog> GetBlog(int id)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(x=> x.Id==id);
            return blog;
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            var blogs = await _dbContext.Blogs.ToListAsync();
            return blogs;
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}