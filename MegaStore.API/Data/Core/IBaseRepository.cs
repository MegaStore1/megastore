using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Data.Core
{
    public interface IBaseRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        // Task<PagedList<T> (T entity)> GetEntities(UserParams userParams) where T

        // Task<Module> GetEntity(int id);
    }
}