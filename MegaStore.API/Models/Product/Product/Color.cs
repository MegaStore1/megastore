using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Models.Product.Product
{
    [Table("mspColor")]
    public class Color : Base
    {
        public int id { get; set; }
        public string colorName { get; set; }
        public int plantId { get; set; }
        public Plant plant { get; set; }
        public ICollection<Product> products { get; set; }
    }
}