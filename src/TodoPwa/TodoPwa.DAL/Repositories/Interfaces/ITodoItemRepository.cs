using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public interface ITodoItemRepository
    {
        void Insert(TodoItemEntity entity);
        void Update(TodoItemEntity entity);
        Task<List<TodoItemEntity>> GetAllAsync();
        Task<TodoItemEntity> GetByIdAsync(Guid id, params Expression<Func<TodoItemEntity, object>>[] includes);
        Task<List<TodoItemEntity>> GetByUsernameAsync(string username);
        Task<List<TodoItemEntity>> GetByNotificationTimeAsync(DateTime notificationTime);
    }
}