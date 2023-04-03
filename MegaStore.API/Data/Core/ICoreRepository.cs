using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Data.Core
{
    public interface ICoreRepository
    {

        Task<PagedList<Country>> GetCountries(UserParams userParams);

        Task<Country> GetCountry(int id);
    }
}