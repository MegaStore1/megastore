using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core.Country;

namespace MegaStore.API.Dtos.Customer
{
    public class ShippingAddressDto
    {
        public int id { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string address { get; set; }
        public required string apartmentOrSuite { get; set; }
        public required string city { get; set; }
        public StateDto state { get; set; }
        public required string postalCode { get; set; }
    }
}