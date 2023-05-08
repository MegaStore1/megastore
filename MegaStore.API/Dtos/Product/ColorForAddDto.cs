using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Product
{
    public class ColorForAddDto
    {
        [Required]
        public string colorName { get; set; }
    }
}