using Microsoft.EntityFrameworkCore;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoItemEntity> TodoItems { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}