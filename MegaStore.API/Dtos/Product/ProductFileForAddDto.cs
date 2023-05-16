using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core;

namespace MegaStore.API.Dtos.Product
{
    public class ProductFileForAddDto : BaseDto
    {
        public int productId { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public long fileLength { get; set; }
        public string contentType { get; set; }
    }
}