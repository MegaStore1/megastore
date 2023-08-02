using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Models.Order
{
    [Table("msoOrder")]
    public class Order : Base
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public MegaStore.API.Models.Customer.Customer customer { get; set; }

        public int plantId { get; set; }
        public Plant plant { get; set; }

        public ICollection<OrderLine> lines { get; set; }
    }
}