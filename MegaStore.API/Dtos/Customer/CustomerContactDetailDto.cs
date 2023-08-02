using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class CustomerContactDetailDto
    {
        [Range(1, Int32.MaxValue)]
        public required int countryId { get; set; }

        [Range(1, Int32.MaxValue)]
        public required int customerId { get; set; }

        [Required]
        [MinLength(9)]
        public required String contact { get; set; }
    }
}