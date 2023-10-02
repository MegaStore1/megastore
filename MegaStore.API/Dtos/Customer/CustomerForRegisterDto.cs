using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class CustomerForRegisterDto
    {
        [EmailAddress]
        [Required]
        public required string email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public required string password { get; set; }

        [Required]
        public required string firstName { get; set; }
        [Required]
        public required string lastName { get; set; }

        public int? plantId { get; set; }

        public int? stateId { get; set; }
    }
}