using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Product;
using MegaStore.API.Dtos.Settings.Company;

namespace MegaStore.API.Dtos.Order
{
    public class OrderForListDto
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public int plantId { get; set; }
        public int lineCount { get; set; }
        public PlantForListDto plant { get; set; }
    }
}