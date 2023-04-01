using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Models.Core
{
    [Table("mscModule")]
    public class Module
    {
        [Column("mscmId")]
        public int id { get; set; }
        [Column("mscmModuleName")]
        public string moduleName { get; set; }
        [Column("mscmStatus")]
        public bool status { get; set; }
        [Column("mscmCreateAt")]
        public DateTime createdAt { get; set; }
    }
}