using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models;

namespace MegaStore.API.Services.Stripe
{
    public class StripePersonDto
    {
        public required UserRole role { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public required string phoneNumber { get; set; }
        public required string ssnLast4 { get; set; }
        public required string dateOfBirth { get; set; }
        public required AddressDto address { get; set; }
    }
}