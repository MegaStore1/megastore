using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.Core;
using MegaStore.API.Dtos.Core;
using MegaStore.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaStore.API.Controllers.Core
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleRepository repository;
        private readonly IMapper mapper;
        public ModuleController(IModuleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetModules([FromQuery] UserParams userParams)
        {
            var modules = await this.repository.GetModules(userParams);
            var modulesToReturn = this.mapper.Map<IEnumerable<ModuleForListDto>>(modules);

            Response.AddPagintaion(modules.currentPage, modules.pageSize, modules.totalCount, modules.totalPages);

            return Ok(modulesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule(int id)
        {
            var module = await this.repository.GetModule(id);
            var moduleToReturn = this.mapper.Map<ModuleForDetailDto>(module);
            return Ok(moduleToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, ModuleForUpdateDto updateDto)
        {
            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //     return Unauthorized();

            var moduleFromRepo = await this.repository.GetModule(id);
            this.mapper.Map(updateDto, moduleFromRepo);

            if (await this.repository.SaveAll())
                return NoContent();

            var response = new Response();
            response.StatusCode = ResponseCode.FAILURE;
            response.Message = "Failed to update";
            return BadRequest(response);
        }

    }
}