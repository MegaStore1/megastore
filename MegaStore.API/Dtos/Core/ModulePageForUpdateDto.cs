using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core
{
    public class ModulePageForUpdateDto
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int moduleId { get; set; }
        [Required]
        public required string pageName { get; set; }

        [Required]
        public required string path { get; set; }

        [Required]
        public required bool isPublic { get; set; }
    }
}