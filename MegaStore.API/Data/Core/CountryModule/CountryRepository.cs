using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core.CountryModel;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.Core.CountryModule
{
    public class CountryRepository : BaseRepository, ICountryRepository
    {
        private readonly DataContext context;
        public CountryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<PagedList<Country>> GetCountries(UserParams userParams)
        {
            var countries = this.context.Countries.AsQueryable();
            return await PagedList<Country>.CreateAsync(countries, userParams.pageNumber, userParams.pageSize);
        }

        public async Task<Country> GetCountry(int id)
        {
            var country = await this.context.Countries.Include(s => s.States).FirstOrDefaultAsync(x => x.id == id);
            return country;
        }
    }
}