using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ProductLineToCreateDto
    {
        [Range(1, Int32.MaxValue)]
        public int amount { get; set; }
        [Range(1, Int32.MaxValue)]
        public long price { get; set; }
        [Range(1, Int32.MaxValue)]
        public long salePrice { get; set; }
        [Range(1, Int32.MaxValue)]
        public int productId { get; set; }
    }
}