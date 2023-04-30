using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Data.Core
{
    public interface IModuleRepository : IBaseRepository
    {
        Task<PagedList<Module>> GetModules(UserParams userParams);
        Task<bool> ModuleExists(string moduleName);
        Task<Module> GetModule(int id);
        Task<ICollection<ModulePage>> GetPages(UserParams userParams);
        Task<ModulePage> GetPage(int id);
    }
}