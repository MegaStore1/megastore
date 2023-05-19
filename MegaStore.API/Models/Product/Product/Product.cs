using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Product.Inventory;

namespace MegaStore.API.Models.Product.Product
{
    [Table("mspProduct")]
    public class Product : Base
    {
        public int id { get; set; }
        public string productName { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
        public int? colorId { get; set; } // int? adds nullable foreign key 
        public Color color { get; set; }
        public ICollection<ProductFile> files { get; set; }
        public ICollection<ProductLine> lines { get; set; }
    }
}