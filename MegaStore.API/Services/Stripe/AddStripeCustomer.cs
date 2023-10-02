using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Services.Stripe
{
    public class AddStripeCustomer
    {
        public required string email { get; set; }
        public string name { get; set; }
        public AddStripeCard creditCard { get; set; }
    }
}