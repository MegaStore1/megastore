using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Product;
using MegaStore.API.Dtos.Settings.Company;

namespace MegaStore.API.Dtos.Order
{
    public class OrderDetailsDto
    {
        public int id { get; set; }
        public int plantId { get; set; }
        public PlantForDetailsDto plant { get; set; }
        public ICollection<OrderLineForDetailsDto> lines { get; set; }
    }
}