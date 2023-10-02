using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Services.Stripe
{
    public class AddressDto
    {
        public required string line1 { get; set; }
        public required string city { get; set; }
        public required string postalCode { get; set; }
        public required string state { get; set; }
    }
}