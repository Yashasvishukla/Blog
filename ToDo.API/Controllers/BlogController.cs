using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Data;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _repo;
        public BlogController(IBlogRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> GetBlogs(){
            var blogs = await _repo.GetBlogs();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id){
            var blog = await _repo.GetBlog(id);
            return Ok(blog);
        }

        [HttpPost]

        public void AddBlog([FromBody] Blog blog){
            _repo.Add(blog);
            _repo.SaveAll();
        }

    }
}