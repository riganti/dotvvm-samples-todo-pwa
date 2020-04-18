using Riganti.Utils.Infrastructure.Core;
using System;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public class TodoItemRepository : RepositoryBase<TodoItemEntity, Guid>, ITodoItemRepository
    {
        public TodoItemRepository(IUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }
    }
}