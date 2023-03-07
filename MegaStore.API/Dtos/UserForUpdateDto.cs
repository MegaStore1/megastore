using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos
{
    public class UserForUpdateDto
    {
        [Required]
        public string Username { get; set; }
    }
}