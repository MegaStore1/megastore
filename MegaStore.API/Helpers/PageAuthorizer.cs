using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MegaStore.API.Data;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Helpers
{
    public class PageAuthorizer
    {
        private readonly DataContext dataContext;

        public PageAuthorizer(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public async Task<bool> IsAuthorized(HttpContext httpContext)
        {
            //Activate it once most of the things are done. 
            return true;
            // Get the current user's identity (e.g., from JWT token or session)
            var userId = 0;

            try
            {
                userId = int.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            }
            catch (Exception ex)
            {
                userId = 0;
            }

            // Get the current API address
            var apiPath = httpContext.Request.Path.ToString();

            var pageExists = await dataContext.ModulePages.Where(mp => mp.path == apiPath).AnyAsync();

            if (!pageExists) return false;

            var pageExistsAndIsPublic = await dataContext.ModulePages.Where(mp => mp.path == apiPath && mp.isPublic).AnyAsync();

            if (pageExistsAndIsPublic) return true;

            var page = await dataContext.ModulePages.FirstOrDefaultAsync(mp => mp.path == apiPath && !mp.isPublic);

            if (page == null) return false;

            // Check if the user has access to the current API address
            var hasAccess = await dataContext.UserRoles
                .Where(ua => ua.userId == userId && ua.pageId == page.id)
                .AnyAsync();

            return hasAccess;
        }
    }
}