using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models;

namespace MegaStore.API.Data
{
    public interface IMegaStoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<PagedList<User>> GetUsers(UserParams userParams);

        Task<User> GetUser(int id);
    }
}