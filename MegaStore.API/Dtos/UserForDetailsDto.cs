using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Dtos.Core.Shared;
using MegaStore.API.Dtos.Settings.Company;
using MegaStore.API.Models;

namespace MegaStore.API.Dtos
{
    public class UserForDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string PhotoUrl { get; set; }
        public ICollection<PhotosForDetailedDto> Photos { get; set; }
        public ICollection<ModulePageDto> Pages { get; set; }

        public PlantForDetailsDto plant { get; set; }
    }
}