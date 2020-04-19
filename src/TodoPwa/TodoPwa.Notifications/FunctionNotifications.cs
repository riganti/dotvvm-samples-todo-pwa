using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Riganti.Utils.Infrastructure.Core;
using System.Threading.Tasks;
using TodoPwa.BL.Facades;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace TodoPwa.Notifications
{
    public class FunctionNotifications
    {
        private readonly ITodoItemFacade todoItemFacade;
        private readonly IDateTimeProvider dateTimeProvider;

        public FunctionNotifications(
            ITodoItemFacade todoItemFacade,
            IDateTimeProvider dateTimeProvider)
        {
            this.todoItemFacade = todoItemFacade;
            this.dateTimeProvider = dateTimeProvider;
        }

        [FunctionName("FunctionNotifications")]
        public async Task Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            var todoItems = await todoItemFacade.GetByNotificationTimeAsync(dateTimeProvider.Now);
            foreach (var todoItem in todoItems)
            {
                log.LogInformation($"Sending notification for item: {todoItem.Title}");
            }
        }
    }
}
