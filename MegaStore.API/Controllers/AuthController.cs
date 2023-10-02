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
using MegaStore.API.Services.Stripe;
using MegaStore.API.Dtos.User;

namespace MegaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IStripeService stripeService;

        public AuthController(IAuthRepository repository, IConfiguration configuration, IMapper mapper, IStripeService stripeService)
        {
            this.configuration = configuration;
            this.repository = repository;
            this.mapper = mapper;
            this.stripeService = stripeService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {

            userForRegisterDto.email = userForRegisterDto.email.ToLower();
            if (await this.repository.UserExists(userForRegisterDto.email))
                return BadRequest("Email already Exists");

            var userToCreate = new User
            {
                email = userForRegisterDto.email,
                firstName = userForRegisterDto.firstName,
                lastName = userForRegisterDto.lastName,
                line1 = userForRegisterDto.line1,
                postalCode = userForRegisterDto.postalCode,
                stateId = userForRegisterDto.stateId,
                role = (UserRole)userForRegisterDto.role,
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
                new Claim(ClaimTypes.Name, userFromRepo.firstName + " " + userFromRepo.lastName),
                new Claim(ClaimTypes.Email, userFromRepo.email),
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