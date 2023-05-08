using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Settings.Company;

namespace MegaStore.API.Dtos.Product
{
    public class CategoryForDetailsDto
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public int plantId { get; set; }
        public PlantForDetailsDto plant { get; set; }
    }
}