using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Services.Stripe
{
    public class StripePayment
    {
        public string customerId { get; set; }
        public string receiptEmail { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public long amount { get; set; }
        public string paymentId { get; set; }
    }
}