using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core.Shared
{
    public class ModulePageDto
    {
        public int id { get; set; }
        public string pageName { get; set; }
        public int moduleId { get; set; }
        public ModuleForDetailDto module { get; set; }
    }
}