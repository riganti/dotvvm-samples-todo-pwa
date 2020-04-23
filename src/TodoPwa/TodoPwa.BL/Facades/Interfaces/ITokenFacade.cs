using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoPwa.BL.Facades
{
    public interface ITokenFacade : IFacade
    {
        Task InsertTokenAsync(string username, string token);
        Task<List<string>> GetTokensByUserIdAsync(Guid userId);
    }
}