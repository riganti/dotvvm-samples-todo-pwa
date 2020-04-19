using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public interface ITodoItemRepository
    {
        void Insert(TodoItemEntity entity);
        Task<List<TodoItemEntity>> GetAllAsync();
        Task<List<TodoItemEntity>> GetByUsernameAsync(string username);
        Task<List<TodoItemEntity>> GetByNotificationTimeAsync(DateTime notificationTime);
    }
}