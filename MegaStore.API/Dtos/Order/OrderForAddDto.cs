using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Order
{
    public class OrderForAddDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please provide at least one line")]
        public ICollection<OrderLineForAddDto> lines { get; set; }
    }
}