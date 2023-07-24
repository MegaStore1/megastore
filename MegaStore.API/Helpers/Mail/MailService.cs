using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MegaStore.API.Helpers.Mail
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettingsOptions;

        public MailService(IOptions<MailSettings> mailSettingsOptions)
        {
            this.mailSettingsOptions = mailSettingsOptions.Value;
        }
        public async Task<bool> sendMail(MailData mailData)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(mailSettingsOptions.senderName, mailSettingsOptions.senderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(mailData.emailToName, mailData.emailToId);
                    emailMessage.To.Add(emailTo);

                    // you can add the CCs and BCCs here.
                    //emailMessage.Cc.Add(new MailboxAddress('Cc Receiver', 'cc@example.com'));
                    //emailMessage.Bcc.Add(new MailboxAddress('Bcc Receiver', 'bcc@example.com'));

                    emailMessage.Subject = mailData.emailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = returnHtmlBody(mailData);

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync(mailSettingsOptions.server, mailSettingsOptions.port, MailKit.Security.SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(mailSettingsOptions.userName, mailSettingsOptions.password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private string returnHtmlBody(MailData mailData)
        {
            // TODO:: Design an HTML template ad return it with data.
            return $"<pre>{mailData.emailBody}</pre>";
        }
    }
}