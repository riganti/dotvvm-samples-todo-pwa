using Microsoft.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity, Guid>, IUserRepository
    {
        public UserRepository(IUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }

        public async Task<UserEntity> GetByUsernameAsync(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(user => user.Username == username);
        }
    }
}