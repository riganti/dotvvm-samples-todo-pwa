using Riganti.Utils.Infrastructure.Core;
using System;

namespace TodoPwa.DAL.Entities
{
    public class EntityBase : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}