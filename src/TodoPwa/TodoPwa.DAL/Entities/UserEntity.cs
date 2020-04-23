using System.Collections.Generic;

namespace TodoPwa.DAL.Entities
{
    public class UserEntity : EntityBase
    {
        public string Username { get; set; }
        public virtual ICollection<TodoItemEntity> TodoItems { get; set; }
        public virtual ICollection<TokenEntity> Tokens { get; set; }
    }
}