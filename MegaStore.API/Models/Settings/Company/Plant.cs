using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;
using MegaStore.API.Models.Product.Product;

namespace MegaStore.API.Models.Settings.Company
{
    [Table("msstPlant")]
    public class Plant : Base
    {
        public int id { get; set; }
        public string plantName { get; set; }
        public long lat { get; set; }
        public long lng { get; set; }

        public int stateId { get; set; }
        public State state { get; set; }

        public int companyId { get; set; }
        public Company company { get; set; }
        public bool status { get; set; }

        public ICollection<Category> categories { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<Color> colors { get; set; }
        public required string stripeId { get; set; }
        public required string industry { get; set; }
        public required string website { get; set; }
        public required string line1 { get; set; }
        public string? line2 { get; set; }
        public required string postalCode { get; set; }
        public required string phoneNumber { get; set; }
        public required string taxId { get; set; }
        public required string city { get; set; }
        public required string accountNumber { get; set; }
        public required string routingNumber { get; set; }
        public required string currency { get; set; }
        public required string registrationNumber { get; set; }
    }
}