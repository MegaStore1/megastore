using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Settings.Company
{
    public class PlantForRegisterDto
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

    }
}