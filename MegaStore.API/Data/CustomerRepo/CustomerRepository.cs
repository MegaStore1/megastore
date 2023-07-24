using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Helpers;
using MegaStore.API.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data.CustomerRepo
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly DataContext context;

        public CustomerRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> CustomerExists(string email)
        {
            if (await this.context.Customers.AnyAsync(x => x.email == email))
                return true;
            return false;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await this.context.Customers
            .Include(m => m.company)
            .Include(m => m.orders)
            .ThenInclude(o => o.plant)
            .FirstOrDefaultAsync(x => x.id == id);
            return customer;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            var customer = await this.context.Customers
            .FirstOrDefaultAsync(x => x.email == email);
            return customer;
        }

        public async Task<CustomerVerificationCode> GetVerificationCode(int id)
        {
            var verificationCode = await this.context.CustomerVerificationCodes
                .OrderByDescending(x => x.creationDate)
                .FirstOrDefaultAsync(x => x.customerId == id);
            return verificationCode;
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