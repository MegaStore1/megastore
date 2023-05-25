using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Product.Inventory;

namespace MegaStore.API.Models.Order
{
    [Table("msoOrderLine")]
    public class OrderLine : Base
    {
        public int id { get; set; }
        public int price { get; set; }
        public double discount { get; set; }
        public int amount { get; set; }
        public int orderId { get; set; }
        public Order order { get; set; }
        public int productLineId { get; set; }
        public ProductLine productLine { get; set; }
    }
}