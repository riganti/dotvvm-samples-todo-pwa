using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoPwa.DAL.Entities
{
    public class TokenEntity : EntityBase
    {
        public string Token { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}