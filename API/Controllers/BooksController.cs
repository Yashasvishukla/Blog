using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _repo;
        public BooksController(IBookService repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _repo.GetBooks();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> UploadBook([FromBody] Book book)
        {
            var bookUploaded = await _repo.UploadBook(book);
            if(bookUploaded == null) return BadRequest("Book Name Already Exists .Unable to upload book");

            return Ok(bookUploaded);
        }
    }
}