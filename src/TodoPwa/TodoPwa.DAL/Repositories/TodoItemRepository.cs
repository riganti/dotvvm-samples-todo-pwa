using Microsoft.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public class TodoItemRepository : RepositoryBase<TodoItemEntity, Guid>, ITodoItemRepository
    {
        public TodoItemRepository(IUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }

        public async Task<List<TodoItemEntity>> GetAllAsync()
        {
            return await Context.TodoItems.ToListAsync();
        }

        public async Task<List<TodoItemEntity>> GetByUsernameAsync(string username)
        {
            return await Context.TodoItems
                .Where(todoItem => todoItem.User.Username == username)
                .ToListAsync();
        }

        public async Task<List<TodoItemEntity>> GetByNotificationTimeAsync(DateTime notificationTime)
        {
            return await Context.TodoItems
                .Where(todoItem => todoItem.NotificationTime.HasValue 
                                   && todoItem.NotificationTime.Value.Date == notificationTime.Date 
                                   && todoItem.NotificationTime.Value.Hour == notificationTime.Hour 
                                   && todoItem.NotificationTime.Value.Minute == notificationTime.Minute)
                .ToListAsync();
        }
    }
}