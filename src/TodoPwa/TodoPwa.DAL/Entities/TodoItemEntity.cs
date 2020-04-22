using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoPwa.DAL.Entities
{
    public class TodoItemEntity : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? NotificationTime { get; set; }
        public bool IsCompleted { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}