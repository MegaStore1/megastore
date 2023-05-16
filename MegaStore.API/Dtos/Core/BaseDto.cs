using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core
{
    public class BaseDto
    {
        public int? creationUserId { get; set; }

        public DateTime? creationDate { get; set; }

        public int? updateUserId { get; set; }
        public DateTime? updateDate { get; set; }
        public bool? status { get; set; }
    }
}