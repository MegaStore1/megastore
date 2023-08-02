using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;

namespace MegaStore.API.Models.Customer
{
    [Table("mscCustomerShippingAddress")]
    public class ShippingAddress : Base
    {
        public int id { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string address { get; set; }
        public required string apartmentOrSuite { get; set; }
        public required string city { get; set; }
        public int stateId { get; set; }
        public State state { get; set; }
        public required string postalCode { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }

    }
}