using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Models.Core
{
    [Table("mscModulePage")]
    public class ModulePage : Base
    {
        public int id { get; set; }
        public string pageName { get; set; }
        public int moduleId { get; set; }
        public Module module { get; set; }
        public ICollection<User> users { get; set; }
    }
}