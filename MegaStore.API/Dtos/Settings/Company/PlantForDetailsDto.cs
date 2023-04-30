using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Settings.Company
{
    public class PlantForDetailsDto
    {
        public int id { get; set; }
        public string plantName { get; set; }
        public DateTime creationDate { get; set; }
        public long lat { get; set; }
        public long lng { get; set; }
    }
}