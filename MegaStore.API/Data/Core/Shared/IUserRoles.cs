using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Data.Core.Shared
{
    public interface IUserRoles : IBaseRepository
    {
        Task<MegaStore.API.Models.Shared.UserRoles> GetRole(int userId, int pageId);
    }
}