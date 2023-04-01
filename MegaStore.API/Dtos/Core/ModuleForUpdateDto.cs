using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core
{
    public class ModuleForUpdateDto
    {
        [Required]
        public string moduleName { get; set; }
        [Required]
        public bool status { get; set; }
    }
}