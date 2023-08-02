using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Models.Core.CountryModel
{
    [Table("mscCountry")]
    public class Country : Base
    {
        public int id { get; set; }

        public String countryName { get; set; }

        public String countryCode { get; set; }
        public required String countryPhoneCode { get; set; }

        public ICollection<State>? States { get; set; }
    }
}