using Microsoft.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public class TokenRepository : RepositoryBase<TokenEntity, Guid>, ITokenRepository
    {
        public TokenRepository(IUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }

        public async Task<TokenEntity> GetByTokenAsync(string token)
        {
            return await Context.Tokens.FirstOrDefaultAsync(item => item.Token == token);
        }

        public async Task<List<TokenEntity>> GetByUserIdAsync(Guid userId)
        {
            return await Context.Tokens.Where(item => item.UserId == userId).ToListAsync();
        }
    }
}