using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.Core.Shared
{
    public class UserRoles : BaseRepository, IUserRoles
    {
        private readonly DataContext context;
        public UserRoles(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Models.Shared.UserRoles> GetRole(int userId, int pageId)
        {
            var role = await this.context.UserRoles.FirstOrDefaultAsync(ur => ur.userId == userId && ur.pageId == pageId);
            return role;
        }
    }
}