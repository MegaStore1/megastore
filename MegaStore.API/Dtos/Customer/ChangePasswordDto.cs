using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class ChangePasswordDto
    {
        [Range(1, Int32.MaxValue)]
        public int id { get; set; }
        [Required]
        public required string oldPassword { get; set; }
        [Required]
        public required string password { get; set; }
        [Required]
        public required string passwordConfirmation { get; set; }
    }
}