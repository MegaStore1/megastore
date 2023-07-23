using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Helpers.Mail
{
    public interface IMailService
    {
        Task<bool> sendMail(MailData mailData);
    }
}