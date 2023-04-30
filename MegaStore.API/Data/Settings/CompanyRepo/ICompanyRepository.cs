using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Data.Settings.CompanyRepo
{
    public interface ICompanyRepository : IBaseRepository
    {
        Task<PagedList<Company>> GetCompanies(UserParams userParams);
        Task<Company> GetCompany(int id);
        Task<bool> CompanyExists(string companyName);
        Task<Plant> GetPlant(int id);
    }
}