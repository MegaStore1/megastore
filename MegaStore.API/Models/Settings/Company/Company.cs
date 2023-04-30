using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Models.Settings.Company
{
    [Table("msstCompany")]
    public class Company : Base
    {
        public int id { get; set; }
        public string companyName { get; set; }
        public ICollection<Plant> plants { get; set; }
    }
}