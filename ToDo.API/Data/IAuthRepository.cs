using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Login(string username,string password);
        Task<User> Register(User user,string password);
        Task<bool> UserExists(string username);
    }
}