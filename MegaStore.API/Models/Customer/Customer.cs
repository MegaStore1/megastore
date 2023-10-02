using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Models.Customer
{
    [Table("mscCustomer")]
    public class Customer : Base
    {
        public int id { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public required byte[] passwordHash { get; set; }
        public required byte[] passwordSalt { get; set; }
        public int? plantId { get; set; }
        public Plant? plant { get; set; }

        public int? stateId { get; set; }
        public State? state { get; set; }
        public ShippingAddress shippingAddress { get; set; }

        public ICollection<MegaStore.API.Models.Order.Order> orders { get; set; }
        public ICollection<CustomerVerificationCode> verificationCodes { get; set; }

        public ICollection<CustomerContactDetail> contacts { get; set; }
        public required string stripeId { get; set; }
    }
}