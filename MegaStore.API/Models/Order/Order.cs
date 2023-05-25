using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Product.Inventory;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Models.Order
{
    [Table("msoOrder")]
    public class Order : Base
    {
        public int id { get; set; }
        public int customerId { get; set; }

        public int plantId { get; set; }
        public Plant plant { get; set; }

        public ICollection<OrderLine> lines { get; set; }
    }
}