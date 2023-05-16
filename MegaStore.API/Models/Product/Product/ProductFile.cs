using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Models.Product.Product
{
    [Table("mspProductFile")]
    public class ProductFile : Base
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public long fileLength { get; set; }
        public string contentType { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }
    }
}