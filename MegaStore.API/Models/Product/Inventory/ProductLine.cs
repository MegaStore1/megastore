using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Order;

namespace MegaStore.API.Models.Product.Inventory
{
    [Table("mspProductLine")]
    public class ProductLine : Base
    {
        public int id { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public double salePrice { get; set; }
        public int productId { get; set; }
        public MegaStore.API.Models.Product.Product.Product product { get; set; }
        public ICollection<OrderLine> orderLines { get; set; }
    }
}