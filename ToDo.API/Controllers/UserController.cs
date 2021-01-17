using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDo.API.Data;
using ToDo.API.Dtos;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _congfig;
        public UserController(IAuthRepository repo,IConfiguration config)
        {
            _repo = repo;
            _congfig = config;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserToLoginDto userToLoginDto){

            var userToLogin = await _repo.Login(userToLoginDto.Username.ToLower(),userToLoginDto.Password);
            if(userToLogin==null) return BadRequest("User Account Doesn't exists");

            // Jwt Token for further authentication purposes.

            // Claims array -> what things to be added inside the header part

            var claims = new Claim[]{
                new Claim(ClaimTypes.NameIdentifier,userToLogin.Id.ToString()),
                new Claim(ClaimTypes.Name,userToLogin.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_congfig.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);



            return Ok( new {
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Regsiter(UserForRegisterDto userForRegisterDto){

            if(await _repo.UserExists(userForRegisterDto.Username.ToLower()))
                return BadRequest("Incorrect Username and Password");

            var userToCreate = new User{
                Username = userForRegisterDto.Username.ToLower()
            };           

            var userCreated = await _repo.Register(userToCreate,userForRegisterDto.Password);

            return StatusCode(201);

            // return CreatedAtRoute('login',user);
        }


    }
}