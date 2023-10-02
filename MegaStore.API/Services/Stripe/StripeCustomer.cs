using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Services.Stripe
{
    public class StripeCustomer
    {
        public string name { get; set; }
        public string email { get; set; }
        public string customerId { get; set; }
    }
}