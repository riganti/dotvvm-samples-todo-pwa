using AutoMapper;
using Riganti.Utils.Infrastructure.Core;
using System.Threading.Tasks;
using TodoPwa.BL.Models;
using TodoPwa.DAL.Entities;
using TodoPwa.DAL.Repositories;

namespace TodoPwa.BL.Facades
{
    public class TodoItemFacade : ITodoItemFacade
    {
        private readonly ITodoItemRepository todoItemRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        public TodoItemFacade(
            ITodoItemRepository todoItemRepository,
            IMapper mapper,
            IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.todoItemRepository = todoItemRepository;
            this.mapper = mapper;
            this.unitOfWorkProvider = unitOfWorkProvider;
        }

        public async Task InsertAsync(TodoItemInsertModel todoItemInsertModel)
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            todoItemRepository.Insert(mapper.Map<TodoItemEntity>(todoItemInsertModel));
            await unitOfWork.CommitAsync();
        }
    }
}
