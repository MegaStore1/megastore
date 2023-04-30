using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.Settings.CompanyRepo;
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

        public CompanyController(ICompanyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpPost("registerCompany")]
        public async Task<IActionResult> RegisterCompany(CompanyForRegisterDto companyDto)
        {
            int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

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
    }
}