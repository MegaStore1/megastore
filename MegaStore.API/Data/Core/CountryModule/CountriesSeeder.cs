using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core.CountryModel;
using Newtonsoft.Json;

namespace MegaStore.API.Data.Core.CountryModule
{
    public class Seed
    {

        public static void SeedCountries(WebApplication app)
        {
            try
            {
                using var scope = app.Services.CreateScope();
                DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var countryData = System.IO.File.ReadAllText("Data/Core/CountryModule/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);
                var countryPhoneCodeData = System.IO.File.ReadAllText("Data/Core/CountryModule/countryphonecodes.json");
                var countryPhoneCodes = JsonConvert.DeserializeObject<List<CountryPhoneCode>>(countryPhoneCodeData);

                var stateData = System.IO.File.ReadAllText("Data/Core/CountryModule/states.json");
                List<State>? allStates = JsonConvert.DeserializeObject<List<State>>(stateData);

                if (null != countries)
                {
                    foreach (var country in countries)
                    {
                        CountryPhoneCode? phoneCode = countryPhoneCodes?.FirstOrDefault(x => x.code == country.countryCode);
                        country.countryPhoneCode = (phoneCode == null ? "no code" : phoneCode.dialCode)!;
                        country.updateUserId = 1;
                        country.creationUserId = 1;
                        if (null != allStates)
                        {
                            ICollection<State> states = allStates.Where(s => s.countryId == country.id).ToList();
                            country.States = states;
                        }
                        context.Countries.Add(country);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}