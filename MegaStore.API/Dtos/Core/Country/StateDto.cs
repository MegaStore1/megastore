using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Core.Country
{
    public class StateDto
    {
        public int id { get; set; }
        public string stateCode { get; set; }
        public string stateName { get; set; }
        public string countryName { get; set; }
    }
}