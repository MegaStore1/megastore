using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ProductFileListForAddDto
    {

        [Range(1, Int32.MaxValue)]
        public int productId { get; set; }

        [Required]
        public ICollection<IFormFile> imagesOrVideos { get; set; }
    }
}