using MimeKit;
using System.Threading.Tasks;

namespace MicroApp.Notification.Api.Services
{
    public interface IMessagesService
    {
        Task SendAsync(MimeMessage message);
    }
}
