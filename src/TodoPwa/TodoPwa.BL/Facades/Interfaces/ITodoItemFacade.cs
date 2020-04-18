using System.Threading.Tasks;
using TodoPwa.BL.Models;

namespace TodoPwa.BL.Facades
{
    public interface ITodoItemFacade : IFacade
    {
        Task InsertAsync(TodoItemInsertModel todoItemInsertModel);
    }
}