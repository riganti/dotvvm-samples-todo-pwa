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
    }

    public class TodoItemListModelMapperProfile : Profile
    {
        public TodoItemListModelMapperProfile()
        {
            CreateMap<TodoItemEntity, TodoItemListModel>();
        }
    }
}