using MailKit.Net.Smtp;
using MicroApp.Common.MailKit;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Threading.Tasks;

namespace MicroApp.Notification.Api.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly MailKitOptions _options;
        private readonly ILogger<MessagesService> _logger;

        public MessagesService(MailKitOptions options, ILogger<MessagesService> logger)
        {
            _options = options;
            _logger = logger;
        }

        public async Task SendAsync(MimeMessage message)
        {
            _logger.LogInformation($"Sending an email message to: '{message.To}'.");

            using (var client = new SmtpClient())
            {
                client.Connect(_options.SmtpHost, _options.Port, true);
                client.Authenticate(_options.Username, _options.Password);

                await client.SendAsync(message);
                client.Disconnect(true);
            }

            _logger.LogInformation($"Sent an email message to: '{message.To}'.");
        }
    }
}
