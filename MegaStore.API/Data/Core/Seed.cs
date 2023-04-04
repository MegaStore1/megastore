using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using Newtonsoft.Json;

namespace MegaStore.API.Data.Core
{
    public class Seed
    {

        public static void SeedCountries(WebApplication app)
        {
            try
            {
                using var scope = app.Services.CreateScope();
                DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var countryData = System.IO.File.ReadAllText("Data/Core/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);

                var stateData = System.IO.File.ReadAllText("Data/Core/states.json");
                var allStates = JsonConvert.DeserializeObject<List<State>>(stateData);

                foreach (var country in countries)
                {
                    country.updateUserId = 1;
                    country.creationUserId = 1;
                    ICollection<State> states = allStates.Where(s => s.countryId == country.id).ToList();
                    country.States = states;

                    context.Countries.Add(country);
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}