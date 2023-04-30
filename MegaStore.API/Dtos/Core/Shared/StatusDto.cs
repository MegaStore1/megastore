using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core.Shared
{
    public class StatusDto
    {
        [Required]
        public bool status { get; set; }
    }
}