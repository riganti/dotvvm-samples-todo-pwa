using System.Threading.Tasks;
using TodoPwa.BL.Models;

namespace TodoPwa.BL.Services
{
    public interface IPushNotificationService : IService
    {
        Task SendNotificationAsync(TodoItemNotificationModel todoItemNotificationModel);
    }
}