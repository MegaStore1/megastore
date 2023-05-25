using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core;
using MegaStore.API.Dtos.Product;

namespace MegaStore.API.Dtos.Order
{
    public class OrderLineForListDto : BaseDto
    {
        public int id { get; set; }
        public int price { get; set; }
        public double discount { get; set; }
        public OrderForListDto order { get; set; }
        public int amount { get; set; }
        public ProductLineDto productLine { get; set; }
    }
}