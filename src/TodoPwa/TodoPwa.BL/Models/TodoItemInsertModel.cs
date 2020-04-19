using AutoMapper;
using System;
using TodoPwa.DAL.Entities;

namespace TodoPwa.BL.Models
{
    public class TodoItemInsertModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? NotificationTime { get; set; }
    }

    public class TodoItemInsertModelMapperProfile : Profile
    {
        public TodoItemInsertModelMapperProfile()
        {
            CreateMap<TodoItemInsertModel, TodoItemEntity>()
                .ForMember(dst => dst.Id, option => option.Ignore());
        }
    }
}
