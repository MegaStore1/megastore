using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Settings.Company
{
    public class CompanyForRegisterDto
    {
        [Required]
        public string companyName { get; set; }
        [MinLength(1, ErrorMessage = "Please provide a plant")]
        public ICollection<PlantForRegisterDto> plants { get; set; }
    }
}