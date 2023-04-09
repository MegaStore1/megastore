using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.Core;
using MegaStore.API.Data.Core.CountryModule;
using MegaStore.API.Dtos.Core.Country;
using MegaStore.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaStore.API.Controllers.Core
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {

        private readonly ICountryRepository repository;
        private readonly IMapper mapper;
        public CountryController(ICountryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetCountries([FromQuery] UserParams userParams)
        {
            var modules = await this.repository.GetCountries(userParams);
            var modulesToReturn = this.mapper.Map<IEnumerable<CountryForListDto>>(modules);

            Response.AddPagintaion(modules.currentPage, modules.pageSize, modules.totalCount, modules.totalPages);

            return Ok(modulesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule(int id)
        {
            var module = await this.repository.GetCountry(id);
            var moduleToReturn = this.mapper.Map<CountryForDetailsDto>(module);
            return Ok(moduleToReturn);
        }

    }
}