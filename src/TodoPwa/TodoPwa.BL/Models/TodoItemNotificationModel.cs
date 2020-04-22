using AutoMapper;
using TodoPwa.DAL.Entities;

namespace TodoPwa.BL.Models
{
    public class TodoItemNotificationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class TodoItemNotificationModelMapperProfile : Profile
    {
        public TodoItemNotificationModelMapperProfile()
        {
            CreateMap<TodoItemEntity, TodoItemNotificationModel>();
        }
    }
}