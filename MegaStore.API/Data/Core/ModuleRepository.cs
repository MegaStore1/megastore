using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.Core
{
    public class ModuleRepository : BaseRepository, IModuleRepository
    {

        private readonly DataContext context;

        public ModuleRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Module> GetModule(int id)
        {
            var module = await this.context.Modules.Include(m => m.pages.OrderBy(p => p.creationDate)).FirstOrDefaultAsync(x => x.id == id);
            return module;
        }

        public async Task<PagedList<Module>> GetModules(UserParams userParams)
        {
            var modules = this.context.Modules.AsQueryable();
            return await PagedList<Module>.CreateAsync(modules, userParams.pageNumber, userParams.pageSize);
        }

        public async Task<ModulePage> GetPage(int id)
        {
            var page = await this.context.ModulePages.Include(m => m.module).FirstOrDefaultAsync(p => p.id == id);
            return page;
        }

        public async Task<ICollection<ModulePage>> GetPages(UserParams userParams)
        {
            var page = await this.context.ModulePages.Include(m => m.module).ToListAsync();
            return page;
        }

        public async Task<bool> ModuleExists(string moduleName)
        {
            return await this.context.Modules.AnyAsync(m => m.moduleName == moduleName);
        }
    }
}