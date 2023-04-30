using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Settings.Company
{
    public class CompanyForDetailedDto
    {
        public int id { get; set; }
        public string companyName { get; set; }
        public DateTime creationDate { get; set; }
        public ICollection<PlantForListDto> plants { get; set; }
    }
}