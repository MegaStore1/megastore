using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Settings.Company;

namespace MegaStore.API.Dtos.Customer
{
    public class CustomerForDetailsDto
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public bool status { get; set; }
        public CompanyForListDto company { get; set; }
    }
}