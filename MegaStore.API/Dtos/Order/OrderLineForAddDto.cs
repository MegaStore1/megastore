using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Order
{
    public class OrderLineForAddDto
    {
        public double price { get; set; }
        public double discount { get; set; }

        [Range(1, Int32.MaxValue)]
        public int amount { get; set; }

        [Range(1, Int32.MaxValue)]
        public int productLineId { get; set; }
    }
}