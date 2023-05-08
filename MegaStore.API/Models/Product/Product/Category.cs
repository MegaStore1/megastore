using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Models.Product.Product
{
    [Table("mspCategory")]
    public class Category : Base
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public int plantId { get; set; }
        public Plant plant { get; set; }

    }
}