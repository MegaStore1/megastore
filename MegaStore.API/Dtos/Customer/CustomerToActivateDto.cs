using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Dtos.Customer
{
    public class CustomerToActivateDto
    {
        [Range(1, Int32.MaxValue)]
        public required int code { get; set; }
        [Range(1, Int32.MaxValue)]
        public int customerId { get; set; }
    }
}