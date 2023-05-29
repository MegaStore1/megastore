using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Order;

namespace MegaStore.API.Dtos.Product
{
    public class ProductForListDto
    {
        public int id { get; set; }
        public string productName { get; set; }
        public CategoryForListDto category { get; set; }
        public ColorDto color { get; set; }
        public int totalAvailable { get; set; }
        public int lineId { get; set; }
        public int total { get; set; }

    }
}