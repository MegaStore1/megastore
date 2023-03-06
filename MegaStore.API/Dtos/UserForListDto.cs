using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string PhotoUrl { get; set; }
    }
}