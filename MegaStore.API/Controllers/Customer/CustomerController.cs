using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.CustomerRepo;
using MegaStore.API.Dtos.Customer;
using MegaStore.API.Helpers;
using MegaStore.API.Helpers.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MegaStore.API.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IMailService mailService;

        public CustomerController(
            ICustomerRepository repository,
            IConfiguration configuration,
            IMapper mapper,
            IMailService mailService)
        {
            this.repository = repository;
            this.configuration = configuration;
            this.mapper = mapper;
            this.mailService = mailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerForRegisterDto customerForRegisterDto)
        {

            customerForRegisterDto.email = customerForRegisterDto.email.ToLower();
            if (await this.repository.CustomerExists(customerForRegisterDto.email))
                return BadRequest("email already Exists");


            MailData mailData = new MailData
            {
                emailToId = customerForRegisterDto.email,
                emailToName = customerForRegisterDto.customerName,
                emailSubject = "MegaStore - Activation Code",
                emailBody = $"Here is your activation code {Extensions.GenerateRandomCode()}"
            };

            if (await mailService.sendMail(mailData))
            {
                var customerToCreate = new MegaStore.API.Models.Customer.Customer
                {
                    email = customerForRegisterDto.email,
                    fullName = customerForRegisterDto.customerName,
                    companyId = customerForRegisterDto.companyId
                };

                var createdCustomer = await this.repository.Register(customerToCreate, customerForRegisterDto.password);
                return StatusCode(201);
            }
            else
            {
                return BadRequest("Sending email failed, please try again");
            }


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CustomerForLoginDto customerForLoginDto)
        {
            var customerFromRepo = await this.repository.Login(customerForLoginDto.email.ToLower(), customerForLoginDto.password);

            if (customerFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customerFromRepo.id.ToString()),
                new Claim(ClaimTypes.Name, customerFromRepo.fullName),
                new Claim(ClaimTypes.Email, customerFromRepo.email),
                new Claim(ClaimTypes.Sid, customerFromRepo.id.ToString())
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

            var customerToReturn = this.mapper.Map<CustomerForDetailsDto>(customerFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                customerToReturn
            });
        }

    }
}