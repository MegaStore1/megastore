using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MegaStore.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace MegaStore.API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var repo = resultContext.HttpContext.RequestServices.GetService<IMegaStoreRepository>();
            var user = await repo.GetUser(userId);

            // Save the Logs after this.
            // user.Id = userId;
            // await repo.SaveAll();
            Console.WriteLine("LOG THE USER AcTIVITIES ::: " + userId);
        }
    }
}