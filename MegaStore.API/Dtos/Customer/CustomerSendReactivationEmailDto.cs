using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class CustomerSendReactivationEmailDto : EmailDto
    {
        [Required]
        public required string customerName { get; set; }
    }
}