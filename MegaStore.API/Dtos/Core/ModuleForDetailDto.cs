using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core
{
    public class ModuleForDetailDto
    {
        public int id { get; set; }
        public string moduleName { get; set; }
        public bool status { get; set; }
        public DateTime createdAt { get; set; }
    }
}