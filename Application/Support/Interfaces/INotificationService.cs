using Application.Support.Models;
using System.Threading.Tasks;

namespace Application.Support.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
