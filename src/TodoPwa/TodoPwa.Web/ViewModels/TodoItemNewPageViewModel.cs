using Microsoft.AspNetCore.Http;
using Riganti.Utils.Infrastructure.Core;
using System.Threading.Tasks;
using TodoPwa.BL.Facades;
using TodoPwa.BL.Models;

namespace TodoPwa.Web.ViewModels
{
    public class TodoItemNewPageViewModel : MasterPageViewModel
    {
        private readonly ITodoItemFacade todoItemFacade;
        private readonly IDateTimeProvider dateTimeProvider;

        public TodoItemInsertModel TodoItemInsertModel { get; set; } = new TodoItemInsertModel();

        public TodoItemNewPageViewModel(
            IHttpContextAccessor httpContextAccessor,
            ITodoItemFacade todoItemFacade,
            IDateTimeProvider dateTimeProvider)
            : base(httpContextAccessor)
        {
            this.todoItemFacade = todoItemFacade;
            this.dateTimeProvider = dateTimeProvider;
        }

        public override async Task Init()
        {
            await base.Init();

            if (!Context.IsPostBack)
            {
                TodoItemInsertModel.NotificationTime = dateTimeProvider.Now;
            }
        }

        public async Task Save()
        {
            TodoItemInsertModel.Username = Username;
            await todoItemFacade.InsertAsync(TodoItemInsertModel);
        }
    }
}
