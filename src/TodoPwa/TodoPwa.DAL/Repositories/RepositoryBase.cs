using Microsoft.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public class RepositoryBase<TEntity, TKey> : EntityFrameworkRepository<TEntity, TKey, AppDbContext>
        where TEntity : class, IEntity<TKey>, new()
    {
        public RepositoryBase(IUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }

        public async Task<UserEntity> GetByUsernameAsync(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(userEntiy => userEntiy.Username == username);
        }
    }
}