using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.User
{
    public class StripeAccountDto
    {

        public required string type { get; set; }

        public required string country { get; set; }

        [EmailAddress]
        public required string email { get; set; }


        public required string company { get; set; }


        public required string businessType { get; set; }


        public required string line1 { get; set; }


        public required string city { get; set; }


        public required string postalCode { get; set; }


        public required string state { get; set; }


        public required string accountNumber { get; set; }


        public required string routingNumber { get; set; }


        public required string currency { get; set; }


        public required string website { get; set; }


        public required string industry { get; set; }


        public required string taxId { get; set; }

        public required string phoneNumber { get; set; }
        public required string registrationNumber { get; set; }
    }
}