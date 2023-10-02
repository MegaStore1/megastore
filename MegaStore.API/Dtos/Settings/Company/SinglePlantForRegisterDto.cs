using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Settings.Company
{
    public class SinglePlantForRegisterDto
    {
        [Required]
        public string plantName { get; set; }

        [Required]
        public long lat { get; set; }
        [Required]
        public long lng { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int stateId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int companyId { get; set; }

        [Required]
        public bool status { get; set; }

        [Required]
        public required string industry { get; set; }

        [Required]
        public required string website { get; set; }

        [Required]
        public required string phoneNumber { get; set; }

        [Required]
        public required string taxId { get; set; }

        [Required]
        public required string line1 { get; set; }

        [Required]
        public required string city { get; set; }

        [Required]
        public required string postalCode { get; set; }


        [Required]
        public required string accountNumber { get; set; }

        [Required]
        public required string routingNumber { get; set; }

        [Required]
        public required string currency { get; set; }
        [Required]
        public required string registrationNumber { get; set; }
    }
}