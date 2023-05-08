using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;
using MegaStore.API.Models.Product.Product;

namespace MegaStore.API.Models.Settings.Company
{
    [Table("msstPlant")]
    public class Plant : Base
    {
        public int id { get; set; }
        public string plantName { get; set; }
        public long lat { get; set; }
        public long lng { get; set; }

        public int stateId { get; set; }
        public State state { get; set; }

        public int companyId { get; set; }
        public Company company { get; set; }
        public bool status { get; set; }

        public ICollection<Category> categories { get; set; }
        public ICollection<User> Users { get; set; }
    }
}