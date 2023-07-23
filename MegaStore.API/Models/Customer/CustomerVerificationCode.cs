using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Models.Customer
{
    [Table("mscCustomerVerificationCode")]
    public class CustomerVerificationCode : Base
    {
        public int id { get; set; }
        public required int code { get; set; }
        public required int customerId { get; set; }
        public required Customer customer { get; set; }
    }
}