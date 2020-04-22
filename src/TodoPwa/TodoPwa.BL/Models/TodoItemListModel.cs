using AutoMapper;
using System;
using TodoPwa.DAL.Entities;

namespace TodoPwa.BL.Models
{
    public class TodoItemListModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TodoItemListModelMapperProfile : Profile
    {
        public TodoItemListModelMapperProfile()
        {
            CreateMap<TodoItemEntity, TodoItemListModel>();
            CreateMap<TodoItemListModel, TodoItemEntity>()
                .ForMember(dst => dst.UserId, option => option.Ignore())
                .ForMember(dst => dst.User, option => option.Ignore())
                .ForMember(dst => dst.NotificationTime, option => option.Ignore());
        }
    }
}