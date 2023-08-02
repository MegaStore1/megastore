using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class ForgotPasswordDto : EmailDto
    {
        [Required]
        public required string password { get; set; }
        [Required]
        public required string passwordConfirmation { get; set; }
        [Range(1, Int32.MaxValue)]
        public int code { get; set; }
    }
}