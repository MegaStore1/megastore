using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos
{
    public class UserForRegisterDto
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
        [Range(1, Int32.MaxValue)]
        public int plantId { get; set; }
    }
}