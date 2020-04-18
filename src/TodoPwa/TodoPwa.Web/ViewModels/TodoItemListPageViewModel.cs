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

        public TodoItemListPageViewModel(ITodoItemFacade todoItemFacade)
        {
            this.todoItemFacade = todoItemFacade;
        }

        public override async Task PreRender()
        {
            await base.PreRender();

            if (!Context.IsPostBack)
            {
                Items = await todoItemFacade.GetAllAsync();
            }
        }
    }
}
