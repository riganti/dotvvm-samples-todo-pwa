using System;

namespace TodoPwa.DAL.Entities
{
    public class TodoItemEntity : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? NotificationTime { get; set; }
    }
}