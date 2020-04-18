using System.Threading.Tasks;
using TodoPwa.BL.Facades;
using TodoPwa.BL.Models;

namespace TodoPwa.Web.ViewModels
{
    public class TodoItemNewPageViewModel : MasterPageViewModel
    {
        private readonly ITodoItemFacade todoItemFacade;

        public TodoItemInsertModel TodoItemInsertModel { get; set; } = new TodoItemInsertModel();

        public TodoItemNewPageViewModel(ITodoItemFacade todoItemFacade)
        {
            this.todoItemFacade = todoItemFacade;
        }

        public async Task Save()
        {
            await todoItemFacade.InsertAsync(TodoItemInsertModel);
        }
    }
}
