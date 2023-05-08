using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ProductForListDto
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int categoryId { get; set; }
        public CategoryForListDto category { get; set; }
    }
}