using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Models.Core
{
    public class Base
    {
        public int creationUserId { get; set; }

        public DateTime creationDate { get; set; }

        public int updateUserId { get; set; }
        public DateTime updateDate { get; set; }
        public bool status { get; set; }
    }
}