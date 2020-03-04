using MailKit.Net.Smtp;
using MicroApp.Common.MailKit;
using MimeKit;
using System.Threading.Tasks;

namespace MicroApp.Notification.Api.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly MailKitOptions _options;

        public MessagesService(MailKitOptions options)
        {
            _options = options;
        }

        public async Task SendAsync(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_options.SmtpHost, _options.Port, true);
                client.Authenticate(_options.Username, _options.Password);

                await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
