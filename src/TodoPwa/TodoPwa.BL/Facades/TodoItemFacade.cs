using AutoMapper;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoPwa.BL.Models;
using TodoPwa.DAL.Entities;
using TodoPwa.DAL.Repositories;

namespace TodoPwa.BL.Facades
{
    public class TodoItemFacade : ITodoItemFacade
    {
        private readonly ITodoItemRepository todoItemRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWorkProvider unitOfWorkProvider;

        public TodoItemFacade(
            ITodoItemRepository todoItemRepository,
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWorkProvider unitOfWorkProvider)
        {
            this.todoItemRepository = todoItemRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.unitOfWorkProvider = unitOfWorkProvider;
        }

        public async Task InsertAsync(TodoItemInsertModel todoItemInsertModel)
        {
            var todoItemEntity = mapper.Map<TodoItemEntity>(todoItemInsertModel);

            using var unitOfWork = unitOfWorkProvider.Create();
            if (todoItemInsertModel.Username != null)
            {
                var userEntity = await userRepository.GetByUsernameAsync(todoItemInsertModel.Username);
                todoItemEntity.UserId = userEntity.Id;
            }

            todoItemRepository.Insert(todoItemEntity);
            await unitOfWork.CommitAsync();
        }

        public async Task<List<TodoItemListModel>> GetAllAsync()
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            return mapper.Map<List<TodoItemListModel>>(await todoItemRepository.GetAllAsync());
        }

        public async Task<List<TodoItemListModel>> GetByUsernameAsync(string username)
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            return mapper.Map<List<TodoItemListModel>>(await todoItemRepository.GetByUsernameAsync(username));
        }

        public async Task<List<TodoItemNotificationModel>> GetByNotificationTimeAsync(DateTime notificationTime)
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            return mapper.Map<List<TodoItemNotificationModel>>(await todoItemRepository.GetByNotificationTimeAsync(notificationTime));
        }
    }
}
