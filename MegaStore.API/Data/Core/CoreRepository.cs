using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Data.Core
{
    public class CoreRepository : ICoreRepository
    {

        private readonly DataContext context;

        public CoreRepository(DataContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Country>> GetCountries(UserParams userParams)
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetCountry(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}