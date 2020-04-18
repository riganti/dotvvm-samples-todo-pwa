using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public interface ITodoItemRepository
    {
        void Insert(TodoItemEntity entity);
    }
}