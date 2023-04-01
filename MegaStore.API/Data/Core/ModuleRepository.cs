using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.Core
{
    public class ModuleRepository : IModuleRepository
    {

        private readonly DataContext context;

        public ModuleRepository(DataContext context)
        {
            this.context = context;
        }


        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public async Task<Module> GetModule(int id)
        {
            var module = await this.context.Modules.FirstOrDefaultAsync(x => x.id == id);
            return module;
        }

        public async Task<PagedList<Module>> GetModules(UserParams userParams)
        {
            var modules = this.context.Modules.AsQueryable();
            return await PagedList<Module>.CreateAsync(modules, userParams.pageNumber, userParams.pageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}