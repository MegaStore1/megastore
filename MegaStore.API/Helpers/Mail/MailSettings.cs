using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Helpers.Mail
{
    public class MailSettings
    {
        public required string server { get; set; }
        public required int port { get; set; }
        public required string senderName { get; set; }
        public required string senderEmail { get; set; }
        public required string userName { get; set; }
        public required string password { get; set; }
    }
}