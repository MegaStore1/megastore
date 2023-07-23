using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Data.Core;
using MegaStore.API.Models.Customer;

namespace MegaStore.API.Data.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task<Customer> Register(Customer user, string password);
        Task<Customer> Login(string email, string password);
        Task<bool> CustomerExists(string email);
    }
}