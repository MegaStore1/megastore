using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.CustomerRepo;
using MegaStore.API.Data.OrderRepo;
using MegaStore.API.Dtos.Customer;
using MegaStore.API.Dtos.Order;
using MegaStore.API.Helpers;
using MegaStore.API.Helpers.Mail;
using MegaStore.API.Models.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MegaStore.API.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IMailService mailService;

        private readonly IOrderRepository orderRepository;

        private readonly string EMAIL_SUBJECT = "Activation Code";

        public CustomerController(
            ICustomerRepository repository,
            IConfiguration configuration,
            IMapper mapper,
            IMailService mailService,
            IOrderRepository orderRepository)
        {
            this.repository = repository;
            this.configuration = configuration;
            this.mapper = mapper;
            this.mailService = mailService;
            this.orderRepository = orderRepository;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerForRegisterDto customerForRegisterDto)
        {

            customerForRegisterDto.email = customerForRegisterDto.email.ToLower();
            if (await this.repository.CustomerExists(customerForRegisterDto.email))
                return BadRequest("email already Exists");

            int verificationCode = Extensions.GenerateRandomCode();

            MailData mailData = new MailData
            {
                emailToId = customerForRegisterDto.email,
                emailToName = customerForRegisterDto.firstName + " " + customerForRegisterDto.lastName,
                emailSubject = EMAIL_SUBJECT,
                emailBody = $"Here is your activation code {verificationCode}"
            };

            if (await mailService.sendMail(mailData))
            {
                var customerToCreate = new MegaStore.API.Models.Customer.Customer
                {
                    email = customerForRegisterDto.email,
                    firstName = customerForRegisterDto.firstName,
                    lastName = customerForRegisterDto.lastName,
                    companyId = customerForRegisterDto.companyId,
                    passwordHash = new byte[] { },
                    passwordSalt = new byte[] { }

                };
                customerToCreate.verificationCodes = new Collection<Models.Customer.CustomerVerificationCode>();
                customerToCreate.verificationCodes.Add(new Models.Customer.CustomerVerificationCode
                {
                    code = verificationCode
                });

                var createdCustomer = await this.repository.Register(customerToCreate, customerForRegisterDto.password);
                return StatusCode(201);
            }
            else
            {
                return BadRequest("Sending email failed, please try again");
            }


        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(CustomerForLoginDto customerForLoginDto)
        {
            var customerFromRepo = await this.repository.Login(customerForLoginDto.email.ToLower(), customerForLoginDto.password);

            if (customerFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customerFromRepo.id.ToString()),
                new Claim(ClaimTypes.Name, customerFromRepo.firstName + " " + customerFromRepo.lastName),
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

        [HttpPost("activate")]
        public async Task<IActionResult> ActivateAccount(CustomerToActivateDto customerToActivateDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            if (customerToActivateDto.customerId != id) return BadRequest();

            var customerFromRepo = await this.repository.GetCustomer(customerToActivateDto.customerId);
            if (customerFromRepo == null) return BadRequest();

            var verificationCode = await this.repository.GetVerificationCode(customerToActivateDto.customerId);

            if (verificationCode.code != customerToActivateDto.code) return BadRequest("Wrong activation code provided");

            customerFromRepo.status = true;
            if (await this.repository.SaveAll())
                return NoContent();

            var response = new Response();
            response.StatusCode = ResponseCode.FAILURE;
            response.Message = "Failed to update";
            return BadRequest(response);
        }

        [AllowAnonymous]
        [HttpPost("resend-email")]
        public async Task<IActionResult> ResendActivationMail(CustomerSendReactivationEmailDto emailDto)
        {
            var customerFromRepo = await this.repository.GetCustomerByEmail(emailDto.email);
            if (customerFromRepo == null) return BadRequest();

            int verificationCode = Extensions.GenerateRandomCode();

            MailData mailData = new MailData
            {
                emailToId = emailDto.email,
                emailToName = emailDto.customerName,
                emailSubject = EMAIL_SUBJECT,
                emailBody = $"Here is your activation code {verificationCode}"
            };

            if (await mailService.sendMail(mailData))
            {
                customerFromRepo.verificationCodes = new Collection<Models.Customer.CustomerVerificationCode>();
                customerFromRepo.verificationCodes.Add(new Models.Customer.CustomerVerificationCode
                {
                    code = verificationCode
                });
                if (await this.repository.SaveAll())
                    return NoContent();

                var response = new Response();
                response.StatusCode = ResponseCode.FAILURE;
                response.Message = "Failed to update code in database";
                return BadRequest(response);
            }
            else
            {
                return BadRequest("Sending email failed, please try again");
            }
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var customerFromRepo = await this.repository.GetCustomerByEmail(forgotPasswordDto.email);
            if (customerFromRepo == null) return BadRequest();

            var latestVerificationCode = await this.repository.GetVerificationCode(customerFromRepo.id);

            if (latestVerificationCode.code != forgotPasswordDto.code) return BadRequest("The provided code is wrong");

            if (forgotPasswordDto.password != forgotPasswordDto.passwordConfirmation) return BadRequest("Passwords doesn't match");

            byte[] passwordHash, passwordSalt;
            Extensions.CreatePasswordHash(forgotPasswordDto.password, out passwordHash, out passwordSalt);
            customerFromRepo.passwordHash = passwordHash;
            customerFromRepo.passwordSalt = passwordSalt;

            if (await this.repository.SaveAll())
                return NoContent();

            var response = new Response();
            response.StatusCode = ResponseCode.FAILURE;
            response.Message = "Failed to update the password";
            return BadRequest(response);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            if (changePasswordDto.id != id) return BadRequest();

            var customerFromRepo = await this.repository.GetCustomer(changePasswordDto.id);
            if (customerFromRepo == null) return BadRequest();

            if (!Extensions.VerifyPasswordHash(changePasswordDto.oldPassword, customerFromRepo.passwordHash, customerFromRepo.passwordSalt))
                return BadRequest("Incorrect old password");

            if (changePasswordDto.password != changePasswordDto.passwordConfirmation) return BadRequest("Passwords doesn't match");

            byte[] passwordHash, passwordSalt;
            Extensions.CreatePasswordHash(changePasswordDto.password, out passwordHash, out passwordSalt);
            customerFromRepo.passwordHash = passwordHash;
            customerFromRepo.passwordSalt = passwordSalt;

            if (await this.repository.SaveAll())
                return NoContent();

            var response = new Response();
            response.StatusCode = ResponseCode.FAILURE;
            response.Message = "Failed to update the password";
            return BadRequest(response);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders([FromQuery] UserParams userParams)
        {
            int customerId = Extensions.GetSessionDetails(this).id;
            if (customerId != userParams.customerId) return BadRequest();

            var orders = await this.orderRepository.GetOrders(userParams, 0);

            var ordersToReturn = this.mapper.Map<IEnumerable<OrderForListDto>>(orders);

            Response.AddPagintaion(orders.currentPage, orders.pageSize, orders.totalCount, orders.totalPages);

            return Ok(ordersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            int customerId = Extensions.GetSessionDetails(this).id;
            if (customerId != id) return BadRequest();

            var customer = await this.repository.GetCustomer(id);

            var customerToReturn = this.mapper.Map<CustomerForDetailsDto>(customer);

            return Ok(customerToReturn);
        }

        [HttpPost("add-shipping-address")]
        public async Task<IActionResult> AddShippingAddress(CustomerShippingAddressForAddDto customerShippingAddressDto)
        {
            int id = Extensions.GetSessionDetails(this).id;

            if (id != customerShippingAddressDto.customerId) return BadRequest();

            var addressToCreate = this.mapper.Map<ShippingAddress>(customerShippingAddressDto);
            addressToCreate.creationUserId = id;
            addressToCreate.updateUserId = id;

            this.repository.Add<ShippingAddress>(addressToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpPost("add-contact")]
        public async Task<IActionResult> AddContact(CustomerContactDetailDto customerContactDetail)
        {
            int id = Extensions.GetSessionDetails(this).id;

            if (id != customerContactDetail.customerId) return BadRequest();

            var contactToCreate = this.mapper.Map<CustomerContactDetail>(customerContactDetail);
            contactToCreate.creationUserId = id;
            contactToCreate.updateUserId = id;

            this.repository.Add<CustomerContactDetail>(contactToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }
    }
}