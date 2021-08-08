using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Core.Utilities.IoC;

namespace Core.Utilities.Email.Mailkit
{
    public class EMailService : IEMailService
    {
        public readonly IConfiguration _configuration;
        public readonly EMailOptions _eMailOptions;
        public EMailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _eMailOptions = _configuration.GetSection("EMailConfiguration").Get<EMailOptions>();
        }
        public async Task Send(string subject, string body, string toEmail)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("E-Ticaret", _eMailOptions.FromMailAddress));
                if (!string.IsNullOrEmpty(toEmail))
                {
                    message.To.Add(new MailboxAddress("E-Ticaret", toEmail));
                }
                else
                {
                    message.To.Add(new MailboxAddress("E-Ticaret", _eMailOptions.ToMailAddress));
                }
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(_eMailOptions.SmtpServer, _eMailOptions.SmtpPort, false);
                    await client.AuthenticateAsync(_eMailOptions.FromMailAddress, _eMailOptions.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {

                throw new InvalidOperationException(e.Message);
            }
        }


    }
}
