using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ProductLineForDetailsDto
    {
        public int id { get; set; }
        public int amount { get; set; }
        public long price { get; set; }
        public long salePrice { get; set; }
        public ProductForDetailsDto product { get; set; }
    }
}