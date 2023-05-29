using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ProductForDetailsDto
    {
        public int id { get; set; }
        public string productName { get; set; }
        public CategoryForDetailsDto category { get; set; }
        public ColorDto color { get; set; }
        public ICollection<ProductFileForListDto> files { get; set; }
        public ICollection<ProductLineDto> lines { get; set; }
        public int totalAvailable { get; set; }
        public int lineId { get; set; }
        public int total { get; set; }
    }
}