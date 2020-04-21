using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoPwa.BL.Facades;
using TodoPwa.BL.Models;

namespace TodoPwa.Web.ViewModels
{
    public class TodoItemListPageViewModel : MasterPageViewModel
    {
        private readonly ITodoItemFacade todoItemFacade;
        public List<TodoItemListModel> Items { get; set; }
        public bool IsChecked { get; set; }
        public TodoItemListPageViewModel(
            IHttpContextAccessor httpContextAccessor,
            ITodoItemFacade todoItemFacade)
            : base(httpContextAccessor)
        {
            this.todoItemFacade = todoItemFacade;
        }

        public override async Task PreRender()
        {
            await base.PreRender();

            if (!Context.IsPostBack)
            {
                if (Username == null)
                {
                    Items = await todoItemFacade.GetAllAsync();
                }
                else
                {
                    Items = await todoItemFacade.GetByUsernameAsync(Username);
                }
            }
        }
    }
}
