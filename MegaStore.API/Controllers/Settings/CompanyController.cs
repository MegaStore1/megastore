using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.Core.CountryModule;
using MegaStore.API.Data.Settings.CompanyRepo;
using MegaStore.API.Dtos.Core.Shared;
using MegaStore.API.Dtos.Settings.Company;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Settings.Company;
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

        public CompanyController(ICompanyRepository repository, IMapper mapper, ICountryRepository countryRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.countryRepository = countryRepository;
        }


        [HttpPost("registerCompany")]
        public async Task<IActionResult> RegisterCompany(CompanyForRegisterDto companyDto)
        {
            int id = Extensions.GetSessionDetails(this).id;

            // Check if company exists
            if (await this.repository.CompanyExists(companyDto.companyName))
                return BadRequest($"Company {companyDto.companyName} already registered");

            var companyToCreate = this.mapper.Map<Company>(companyDto);

            companyToCreate.creationUserId = id;
            companyToCreate.updateUserId = id;

            foreach (Plant plant in companyToCreate.plants)
            {
                plant.creationUserId = id;
                plant.updateUserId = id;
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
        public async Task<IActionResult> RegisterPlant(SinglePlantForRegisterDto plantDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            var company = await this.repository.GetCompany(plantDto.companyId);

            if (null == company)
                return BadRequest($"Company with the id {plantDto.companyId} does not exists");

            var state = await this.countryRepository.GetState(plantDto.stateId);

            if (null == state)
                return BadRequest($"State with the id {plantDto.stateId} does not exists");

            var plantToCreate = this.mapper.Map<Plant>(plantDto);
            plantToCreate.creationUserId = id;
            plantToCreate.updateUserId = id;

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

    }
}