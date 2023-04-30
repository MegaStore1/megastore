using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Data;
using MegaStore.API.Data.Core;
using MegaStore.API.Data.Core.Shared;
using MegaStore.API.Dtos;
using MegaStore.API.Dtos.User;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaStore.API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMegaStoreRepository repository;
        private readonly IModuleRepository moduleRepository;
        private readonly IMapper mapper;
        private readonly IUserRoles userRoles;
        private readonly IMegaStoreRepository userRepository;

        public UserController(IMegaStoreRepository repository,
                                IModuleRepository moduleRepository,
                                IMapper mapper,
                                IUserRoles userRoles,
                                IMegaStoreRepository userRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userRoles = userRoles;
            this.userRepository = userRepository;
            this.moduleRepository = moduleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserParams userParams)
        {
            // var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // var userFromRepo = await this.repository.GetUser(currentUserId);

            // userParams.UserId = currentUserId;

            var users = await this.repository.GetUsers(userParams);
            var usersToReturn = this.mapper.Map<IEnumerable<UserForListDto>>(users);

            Response.AddPagintaion(users.currentPage, users.pageSize, users.totalCount, users.totalPages);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await this.repository.GetUser(id);

            var userToReturn = this.mapper.Map<UserForDetailsDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var userFromRepo = await this.repository.GetUser(id);
            this.mapper.Map(userForUpdateDto, userFromRepo);

            if (await this.repository.SaveAll())
                return NoContent();

            var response = new Response();
            response.StatusCode = ResponseCode.FAILURE;
            response.Message = "Failed to update";
            return BadRequest(response);
        }

        [HttpPost("grantPages")]
        public async Task<IActionResult> GrantPage(PagesForGrantDto pagesForGrantDto)
        {
            var user = await this.userRepository.GetUser(pagesForGrantDto.UserId);

            if (user == null)
            {
                return BadRequest($"User with the id {pagesForGrantDto.UserId} does not exists");
            }
            else
            {
                // Check if user already has the roles.
                foreach (int id in pagesForGrantDto.pagesId)
                {
                    if (user.pages.Any(p => p.id == id)) return BadRequest($"User already has the roles for the page {id}");
                }

            }


            ICollection<MegaStore.API.Models.Shared.UserRoles> roles = new Collection<MegaStore.API.Models.Shared.UserRoles>();
            foreach (int id in pagesForGrantDto.pagesId)
            {
                var page = await this.moduleRepository.GetPage(id);
                if (page == null) return BadRequest($"Page does not exists with the id {id}");
                MegaStore.API.Models.Shared.UserRoles role = new MegaStore.API.Models.Shared.UserRoles();
                role.userId = pagesForGrantDto.UserId;
                role.pageId = id;
                roles.Add(role);
            }

            foreach (MegaStore.API.Models.Shared.UserRoles role in roles)
            {
                this.userRoles.Add(role);
            }

            await this.userRoles.SaveAll();
            return NoContent();
        }

        [HttpDelete("refusePage/{userId}/{pageId}")]
        public async Task<IActionResult> RefusePage(int userId, int pageId)
        {
            var moduleToDelete = await this.userRoles.GetRole(userId, pageId);
            this.userRoles.Delete(moduleToDelete);
            await this.userRoles.SaveAll();
            return NoContent();
        }
    }
}