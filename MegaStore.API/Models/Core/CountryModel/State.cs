using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Models.Core.CountryModel
{
    [Table("mscState")]
    public class State : Base
    {
        public int id { get; set; }
        public string stateCode { get; set; }
        public string stateName { get; set; }
        public int countryId { get; set; }
        public Country country { get; set; }
        public ICollection<Plant> plants { get; set; }
        public ICollection<MegaStore.API.Models.Customer.Customer> customers { get; set; }
    }
}