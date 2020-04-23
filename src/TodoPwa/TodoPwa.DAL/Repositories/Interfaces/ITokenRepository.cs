using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public interface ITokenRepository
    {
        void Insert(TokenEntity item);
        Task<TokenEntity> GetByTokenAsync(string token);
        Task<List<TokenEntity>> GetByUserIdAsync(Guid userId);
    }
}