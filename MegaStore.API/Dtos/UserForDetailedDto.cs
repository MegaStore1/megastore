using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models;

namespace MegaStore.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string PhotoUrl { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}