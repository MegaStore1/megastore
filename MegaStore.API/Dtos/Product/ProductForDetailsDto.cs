using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ProductForDetailsDto
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int categoryId { get; set; }
        public CategoryForDetailsDto category { get; set; }
    }
}