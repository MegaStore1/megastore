using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core.Country;
using MegaStore.API.Dtos.Core.Shared;
using MegaStore.API.Dtos.Settings.Company;
using MegaStore.API.Models;

namespace MegaStore.API.Dtos
{
    public class UserForDetailsDto
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string postalCode { get; set; }
        public int stateId { get; set; }
        public StateDto? state { get; set; }

        public string PhotoUrl { get; set; }
        public ICollection<PhotosForDetailedDto>? Photos { get; set; }
        public ICollection<ModulePageDto>? Pages { get; set; }

        public PlantForDetailsDto? plant { get; set; }
    }
}