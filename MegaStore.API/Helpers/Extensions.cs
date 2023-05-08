using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MegaStore.API.Helpers
{
    public static class Extensions
    {
        public static Session session;
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static void AddPagintaion(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

        public static async void ErrorResponse(this HttpResponse response, string message)
        {
            response.StatusCode = 400;
            var bytes = Encoding.UTF8.GetBytes(message);
            await response.Body.WriteAsync(bytes);
        }


        public static int CalculateAge(this DateTime dateTime)
        {
            var age = DateTime.Today.Year - dateTime.Year;

            if (dateTime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }

        public static Session GetSessionDetails(ControllerBase controller)
        {
            int id = int.Parse(controller.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            int plantId = int.Parse(controller.User.FindFirst(ClaimTypes.Sid)!.Value);
            string username = controller.User.FindFirst(ClaimTypes.Name)!.Value;
            string email = controller.User.FindFirst(ClaimTypes.Email)!.Value;

            session = new Session();
            session.id = id;
            session.plantId = plantId;
            session.username = username;
            session.email = email;
            return session;
        }
    }
}