using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ProductForAddDto
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int categoryId { get; set; }

        [Required]
        public string productName { get; set; }
    }
}