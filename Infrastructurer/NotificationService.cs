using Application.Support.Interfaces;
using Application.Support.Models;
using System.Threading.Tasks;

namespace Infrastructurer
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
