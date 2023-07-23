using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext context;

        public CustomerRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<bool> CustomerExists(string email)
        {
            if (await this.context.Customers.AnyAsync(x => x.email == email))
                return true;
            return false;
        }

        public async Task<Customer> Login(string email, string password)
        {
            var customer = await this.context.Customers
                .Include(o => o.company)
                .FirstOrDefaultAsync(x => x.email == email);

            if (null == customer) return null;

            if (!Extensions.VerifyPasswordHash(password, customer.passwordHash, customer.passwordSalt))
                return null;

            return customer;
        }

        public async Task<Customer> Register(Customer customer, string password)
        {
            byte[] passwordHash, passwordSalt;
            Extensions.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            customer.passwordHash = passwordHash;
            customer.passwordSalt = passwordSalt;

            await this.context.Customers.AddAsync(customer);
            await this.context.SaveChangesAsync();
            return customer;
        }
    }
}