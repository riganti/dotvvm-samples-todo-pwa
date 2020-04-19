using System.Collections.Generic;
using System.Threading.Tasks;
using TodoPwa.BL.Models;

namespace TodoPwa.BL.Facades
{
    public interface ITodoItemFacade : IFacade
    {
        Task InsertAsync(TodoItemInsertModel todoItemInsertModel);
        Task<List<TodoItemListModel>> GetAllAsync();
        Task<List<TodoItemListModel>> GetByUsernameAsync(string username);
    }
}