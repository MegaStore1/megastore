using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.User
{
    public class PagesForGrantDto
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int UserId { get; set; }
        [MinLength(1)]
        public int[] pagesId { get; set; }
    }
}