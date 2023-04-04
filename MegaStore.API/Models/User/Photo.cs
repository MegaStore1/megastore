using System;
using System.ComponentModel.DataAnnotations.Schema;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Models
{
    [Table("msuPhoto")]
    public class Photo : Base
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }

        public bool IsMain { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}