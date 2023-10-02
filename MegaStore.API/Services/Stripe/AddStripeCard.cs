using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Services.Stripe
{
    public class AddStripeCard
    {
        public string name { get; set; }
        public string cardNumber { get; set; }
        public string expirationYear { get; set; }
        public string expirationMonth { get; set; }
        public string cvc { get; set; }
    }
}