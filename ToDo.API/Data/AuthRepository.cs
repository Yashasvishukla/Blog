using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dbContext;

        public AuthRepository(DataContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Username.Equals(username));
            if(user == null) return null;

            if(!VerfifyPasswordHash(user,password)) return null;

            return user;

        }

        private bool VerfifyPasswordHash(User user, string password)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt)){
                byte[] ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for(int i=0;i<ComputedHash.Length;i++){
                    if(user.PasswordHash[i]!=ComputedHash[i]) return false;
                }
            }

            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, paswordSalt;
            CreatePasswordHash(password, out passwordHash, out paswordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = paswordSalt;

            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] paswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                paswordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if(await _dbContext.Users.AnyAsync(x=>x.Username.Equals(username)))
                return true;
            return false;
        }
    }
}