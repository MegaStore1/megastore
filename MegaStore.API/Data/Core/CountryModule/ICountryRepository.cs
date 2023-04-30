using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;

namespace MegaStore.API.Data.Core.CountryModule
{
    public interface ICountryRepository : IBaseRepository
    {
        Task<PagedList<Country>> GetCountries(UserParams userParams);

        Task<Country> GetCountry(int id);

        Task<State> GetState(int id);
    }
}