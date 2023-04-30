using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data.Core;
using MegaStore.API.Dtos.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;
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

        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleForUpdateDto moduleDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            // Check if module exists
            if (await this.repository.ModuleExists(moduleDto.moduleName))
                return BadRequest($"Module {moduleDto.moduleName} already exists");
            var moduleToCreate = this.mapper.Map<Module>(moduleDto);
            moduleToCreate.creationUserId = id;
            moduleToCreate.updateUserId = id;
            this.repository.Add<Module>(moduleToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var moduleToDelete = await this.repository.GetModule(id);
            this.repository.Delete(moduleToDelete);
            await this.repository.SaveAll();
            return NoContent();
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


        [HttpPost("addPage")]
        public async Task<IActionResult> AddPage(ModulePageForUpdateDto modulePageDto)
        {
            int id = Extensions.GetSessionDetails(this).id;
            var module = await this.repository.GetModule(modulePageDto.moduleId);

            if (null == module)
                return BadRequest("Module doesn't exist");

            var pageToCreate = this.mapper.Map<ModulePage>(modulePageDto);
            pageToCreate.creationUserId = id;
            pageToCreate.updateUserId = id;
            this.repository.Add<ModulePage>(pageToCreate);
            await this.repository.SaveAll();
            return NoContent();
        }
    }
}