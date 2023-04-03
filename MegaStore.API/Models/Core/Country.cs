using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Models.Core
{
    [Table("mscCountry")]
    public class Country
    {
        [Column("mscId")]
        public int id { get; set; }

        [Column("mscCountryName")]
        public String countryName { get; set; }

        [Column("mscCountryCode")]
        public String countryCode { get; set; }

        [Column("mscCreationUserId")]
        public int creationUserId { get; set; }

        [Column("mscCreationDate")]
        public DateTime creationDate { get; set; }
    }
}