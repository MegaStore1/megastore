using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Helpers.Mail
{
    public class MailData
    {
        public required string emailToId { get; set; }
        public required string emailToName { get; set; }
        public required string emailSubject { get; set; }
        public required string emailBody { get; set; }
    }
}