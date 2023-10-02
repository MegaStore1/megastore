using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Helpers.Validators;
using MegaStore.API.Models;

namespace MegaStore.API.Dtos
{
    public class UserForRegisterDto
    {

        [EmailAddress]
        [Required]
        public required string email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public required string Password { get; set; }

        [Required]
        public required string firstName { get; set; }
        [Required]
        public required string lastName { get; set; }
        [Required]
        public required string line1 { get; set; }

        public string? line2 { get; set; }
        [Required]
        public required string postalCode { get; set; }
        [Range(1, Int32.MaxValue)]
        public required int stateId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int plantId { get; set; }

        [UserRoleEnumRange(typeof(UserRole))]
        public required int role { get; set; }
    }
}