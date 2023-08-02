using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;

namespace MegaStore.API.Models.Customer
{
    [Table("mscCustomerContactDetail")]
    public class CustomerContactDetail : Base
    {
        public int id { get; set; }
        public required int countryId { get; set; }
        public Country? country { get; set; }
        public int customerId { get; set; }
        public Customer? customer { get; set; }

        public required String contact { get; set; }
    }
}