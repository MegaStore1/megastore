using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core.Country;

namespace MegaStore.API.Dtos.Customer
{
    public class CustomerContactDetailForDetailDto
    {
        public int id { get; set; }
        public CountryForListDto? country { get; set; }
        public required String contact { get; set; }
    }
}