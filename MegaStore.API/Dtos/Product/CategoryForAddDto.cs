using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class CategoryForAddDto
    {
        [Required]
        public string categoryName { get; set; }
    }
}