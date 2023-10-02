using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data;
using MegaStore.API.Data.Core.CountryModule;
using MegaStore.API.Data.Settings.CompanyRepo;
using MegaStore.API.Dtos.Core.Shared;
using MegaStore.API.Dtos.Settings.Company;
using MegaStore.API.Dtos.User;
using MegaStore.API.Helpers;
using MegaStore.API.Models;
using MegaStore.API.Models.Core.CountryModel;
using MegaStore.API.Models.Settings.Company;
using MegaStore.API.Services.Stripe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaStore.API.Controllers.Settings
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository repository;
        private readonly IMapper mapper;
        private readonly ICountryRepository countryRepository;
        private readonly IMegaStoreRepository megaStoreRepository;
        private readonly IStripeService stripeService;

        public CompanyController(
            ICompanyRepository repository,
            IMapper mapper,
            ICountryRepository countryRepository,
            IMegaStoreRepository megaStoreRepository,
            IStripeService stripeService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.countryRepository = countryRepository;
            this.megaStoreRepository = megaStoreRepository;
            this.stripeService = stripeService;
        }


        [HttpPost("registerCompany")]
        public async Task<IActionResult> RegisterCompany(CompanyForRegisterDto companyDto, CancellationToken cancellationToken)
        {
            int id = Extensions.GetSessionDetails(this).id;
            var user = await this.megaStoreRepository.GetUser(id);
            if (user == null) return Unauthorized();
            // Check if company exists
            if (await this.repository.CompanyExists(companyDto.companyName))
                return BadRequest($"Company {companyDto.companyName} already registered");

            var companyToCreate = this.mapper.Map<Company>(companyDto);

            companyToCreate.creationUserId = id;
            companyToCreate.updateUserId = id;

            foreach (SinglePlantForRegisterDto plantDto in companyDto.plants)
            {
                var plant = this.mapper.Map<Plant>(plantDto);
                var state = await this.countryRepository.GetState(plant.stateId);

                if (null == state)
                    return BadRequest($"State with the id {plant.stateId} does not exists");

                var country = await this.countryRepository.GetCountry(state.countryId);
                if (null == state)
                    return BadRequest($"Country with the id {state.countryId} does not exists");
                var stripeAccount = await this.registerStripeAccountForPlant(
                    user.email,
                    state,
                    companyToCreate.companyName,
                    plantDto,
                    cancellationToken
                );
                if (stripeAccount == null) return BadRequest("Failed to create online payment account");
                plant.creationUserId = id;
                plant.updateUserId = id;
                plant.stripeId = stripeAccount.id;
            }

            this.repository.Add<Company>(companyToCreate);

            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery] UserParams userParams)
        {
            var companies = await this.repository.GetCompanies(userParams);
            var companiesToReturn = this.mapper.Map<IEnumerable<CompanyForListDto>>(companies);

            Response.AddPagintaion(companies.currentPage, companies.pageSize, companies.totalCount, companies.totalPages);

            return Ok(companiesToReturn);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await this.repository.GetCompany(id);
            var companyToReturn = this.mapper.Map<CompanyForDetailedDto>(company);

            return Ok(companyToReturn);
        }

        [HttpPost("registerPlant")]
        public async Task<IActionResult> RegisterPlant(SinglePlantForRegisterDto plantDto, CancellationToken cancellationToken)
        {
            int id = Extensions.GetSessionDetails(this).id;

            var user = await this.megaStoreRepository.GetUser(id);
            if (user == null) return Unauthorized();
            var company = await this.repository.GetCompany(plantDto.companyId);

            if (null == company)
                return BadRequest($"Company with the id {plantDto.companyId} does not exists");

            var state = await this.countryRepository.GetState(plantDto.stateId);

            if (null == state)
                return BadRequest($"State with the id {plantDto.stateId} does not exists");

            var stripeAccount = await this.registerStripeAccountForPlant(
                user.email, state, company.companyName, plantDto, cancellationToken
            );

            if (stripeAccount == null) return BadRequest("Failed to create online payment account");

            var plantToCreate = this.mapper.Map<Plant>(plantDto);
            plantToCreate.creationUserId = id;
            plantToCreate.updateUserId = id;
            plantToCreate.stripeId = stripeAccount.id;

            this.repository.Add<Plant>(plantToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpPut("activeDeactivePlant/{id}")]
        public async Task<IActionResult> ActiveDeactivePlant(int id, StatusDto statusDto)
        {
            int userId = Extensions.GetSessionDetails(this).id;

            var plantFromRepo = await this.repository.GetPlant(id);

            if (null == plantFromRepo) return BadRequest($"Plant with the id {id} does not exits");

            plantFromRepo.updateUserId = userId;
            this.mapper.Map(statusDto, plantFromRepo);

            if (await this.repository.SaveAll())
                return NoContent();

            var response = new Response();
            response.StatusCode = ResponseCode.FAILURE;
            response.Message = "Failed to update";
            return BadRequest(response);
        }

        [HttpPost("registerPersonForStripeService/{id}")]
        public async Task<IActionResult> RegisterPersonForStripeService(int id, CancellationToken cancellationToken)
        {
            int plantId = Extensions.GetSessionDetails(this).plantId;
            var plant = await this.repository.GetPlant(plantId);
            if (plant == null) return BadRequest("Plant does not exists");

            var user = await this.megaStoreRepository.GetUser(id);
            if (user == null) return BadRequest("User does not exists");

            // TODO: Add more checks

            var options = new StripePersonDto
            {
                role = (UserRole)user.role,
                firstName = user.firstName,
                lastName = user.lastName,
                ssnLast4 = "1234",
                dateOfBirth = "1901-01-01",
                email = user.email,
                phoneNumber = "+43787778956",
                address = new AddressDto
                {
                    line1 = user.line1,
                    city = user.state.stateCode,
                    postalCode = user.postalCode,
                    state = user.state.stateCode
                }
            };
            var addedStripePerson = await this.stripeService.AddStripeAccountPerson(user.plant.stripeId, user.stateId, options, cancellationToken);

            return NoContent();
        }

        private async Task<StripeAccount> registerStripeAccountForPlant(
            string email,
            State state,
            string companyName,
            SinglePlantForRegisterDto plantDto,
            CancellationToken cancellationToken)
        {
            var stripeAccount = new StripeAccountDto()
            {
                email = email,
                type = "custom",
                country = state.country.countryCode,
                company = companyName + "/" + plantDto.plantName,
                businessType = "company",
                line1 = plantDto.line1,
                city = plantDto.city,
                postalCode = plantDto.postalCode,
                state = state.stateCode,
                accountNumber = plantDto.accountNumber,
                routingNumber = plantDto.routingNumber,
                currency = plantDto.currency,
                website = plantDto.website,
                industry = plantDto.industry,
                taxId = plantDto.taxId,
                phoneNumber = plantDto.phoneNumber,
                registrationNumber = plantDto.registrationNumber
            };
            var createdStripeAccount = await this.stripeService.AddStripeAccountAsync(stripeAccount, cancellationToken);
            return createdStripeAccount;
        }
    }
}