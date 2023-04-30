using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core.Country;

namespace MegaStore.API.Dtos.Settings.Company
{
    public class PlantForListDto
    {
        public int id { get; set; }
        public string plantName { get; set; }
        public DateTime creationDate { get; set; }
        public long lat { get; set; }
        public long lng { get; set; }
        public StateDto state { get; set; }
        public bool status { get; set; }
    }
}