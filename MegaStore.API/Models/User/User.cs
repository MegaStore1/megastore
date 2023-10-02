using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Models
{
    [Table("msuUser")]
    public class User : Base
    {
        public int Id { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public required string line1 { get; set; }
        public string? line2 { get; set; }
        public required string postalCode { get; set; }
        public required int stateId { get; set; }
        public State? state { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Photo>? Photos { get; set; }
        public ICollection<ModulePage>? pages { get; set; }
        public required int plantId { get; set; }
        public Plant? plant { get; set; }
        public required UserRole role { get; set; }
    }
}