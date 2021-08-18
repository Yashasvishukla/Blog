using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IBookService
    {
        Task<IReadOnlyList<Book>> GetBooks();
        Task<Book> UploadBook(Book book);
    }
}