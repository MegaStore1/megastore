using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Models.Shared
{
    [Table("mssUserRoles")]
    public class UserRoles : Base
    {
        public int userId { get; set; }
        public int pageId { get; set; }

        public User user { get; set; }
        public ModulePage page { get; set; }
    }
}