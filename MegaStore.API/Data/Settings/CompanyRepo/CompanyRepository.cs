using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Settings.Company;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.Settings.CompanyRepo
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        private readonly DataContext context;

        public CompanyRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> CompanyExists(string companyName)
        {
            return await this.context.Companies.AnyAsync(c => c.companyName == companyName);
        }

        public async Task<PagedList<Company>> GetCompanies(UserParams userParams)
        {
            var companies = this.context.Companies.OrderByDescending(c => c.companyName).AsQueryable();

            return await PagedList<Company>.CreateAsync(companies, userParams.pageNumber, userParams.pageSize);
        }

        public Task<Company> GetCompany(int id)
        {
            var company = this.context.Companies.Include(c => c.plants).FirstOrDefaultAsync(c => c.id == id);
            return company;
        }
    }
}