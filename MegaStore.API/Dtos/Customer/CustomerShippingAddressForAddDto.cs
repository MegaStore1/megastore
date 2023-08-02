using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class CustomerShippingAddressForAddDto
    {
        [Required]
        public required string firstName { get; set; }
        [Required]
        public required string lastName { get; set; }
        [Required]
        public required string address { get; set; }
        [Required]
        public required string apartmentOrSuite { get; set; }
        [Required]
        public required string city { get; set; }
        [Range(1, Int32.MaxValue)]
        public int stateId { get; set; }
        [Required]
        public required string postalCode { get; set; }
        [Range(1, Int32.MaxValue)]
        public int customerId { get; set; }
    }
}