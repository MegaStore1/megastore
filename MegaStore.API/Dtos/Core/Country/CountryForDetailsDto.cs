using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core.Country
{
    public class CountryForDetailsDto
    {
        public int id { get; set; }

        public String countryName { get; set; }

        public String countryCode { get; set; }

        public ICollection<StateDto>? States { get; set; }
    }
}