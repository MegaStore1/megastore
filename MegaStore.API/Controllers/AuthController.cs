using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MegaStore.API.Data;
using MegaStore.API.Dtos;
using MegaStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace MegaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        public AuthController(IAuthRepository repository, IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            userForRegisterDto.Email = userForRegisterDto.Email.ToLower();
            if (await this.repository.UserExists(userForRegisterDto.Email))
                return BadRequest("Email already Exists");

            var userToCreate = new User
            {
                Email = userForRegisterDto.Email,
                Username = userForRegisterDto.Username,
                plantId = userForRegisterDto.plantId
            };

            var createdUser = await this.repository.Register(userToCreate, userForRegisterDto.Password);
            // Nothing, just to test commit.
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await this.repository.Login(userForLoginDto.email.ToLower(), userForLoginDto.password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
                new Claim(ClaimTypes.Email, userFromRepo.Email),
                new Claim(ClaimTypes.Sid, userFromRepo.plantId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding
                .UTF8.GetBytes(this.configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userToReturn = this.mapper.Map<UserForDetailsDto>(userFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                userToReturn
            });
        }
    }
}