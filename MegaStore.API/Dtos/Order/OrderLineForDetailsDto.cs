using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core;
using MegaStore.API.Dtos.Product;

namespace MegaStore.API.Dtos.Order
{
    public class OrderLineForDetailsDto : BaseDto
    {
        public int id { get; set; }
        public int price { get; set; }
        public double discount { get; set; }
        public int amount { get; set; }
        public OrderDetailsDto order { get; set; }
        public ProductLineForDetailsDto productLine { get; set; }
    }
}