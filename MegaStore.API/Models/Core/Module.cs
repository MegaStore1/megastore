using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Models.Core
{
    [Table("mscModule")]
    public class Module : Base
    {
        public int id { get; set; }
        public string moduleName { get; set; }
        public bool status { get; set; }
        public DateTime creationDate { get; set; }

        public ICollection<ModulePage> pages { get; set; }
    }
}