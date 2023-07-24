using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class EmailDto
    {
        [Required]
        [EmailAddress]
        public required string email { get; set; }
    }
}