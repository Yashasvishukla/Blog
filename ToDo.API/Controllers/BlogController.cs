using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Data;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _dbContext;
        public BlogController(DataContext dbContext)
        {
            _dbContext = dbContext;

        }


        [HttpGet]
        public async Task<IActionResult> GetBlogs(){
            var blogs = await _dbContext.Blogs.ToListAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id){
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(x=> x.Id == id);
            if(blog == null){
                return NoContent();
            }

            return Ok(blog);
        }


        // How do we separate these two request Look for that part
        // [HttpGet]
        // public async Task<IActionResult> GetBlogByAuthorName(string Author){
        //     var blog = await _dbContext.Blogs.FirstOrDefaultAsync(x=>x.Author.Equals(Author));
        //     if(blog == null) return NoContent();
        //     return Ok(blog); 
        // }

    }
}