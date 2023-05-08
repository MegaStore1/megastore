using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core.Shared
{
    public class Session
    {
        public int id { get; set; }
        public int plantId { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}