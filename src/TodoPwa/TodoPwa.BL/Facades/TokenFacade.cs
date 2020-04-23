using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoPwa.DAL.Entities;
using TodoPwa.DAL.Repositories;

namespace TodoPwa.BL.Facades
{
    public class TokenFacade : ITokenFacade
    {
        private readonly IUnitOfWorkProvider unitOfWorkProvider;
        private readonly ITokenRepository tokenRepository;
        private readonly IUserRepository userRepository;

        public TokenFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            ITokenRepository tokenRepository,
            IUserRepository userRepository)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
            this.tokenRepository = tokenRepository;
            this.userRepository = userRepository;
        }

        public async Task InsertTokenAsync(string username, string token)
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            var existingTokenEntity = await tokenRepository.GetByTokenAsync(token);
            if (existingTokenEntity == null)
            {
                var userEntity = await userRepository.GetByUsernameAsync(username);
                var tokenEntity = new TokenEntity
                {
                    UserId = userEntity.Id,
                    Token = token
                };

                tokenRepository.Insert(tokenEntity);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<List<string>> GetTokensByUserIdAsync(Guid userId)
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            var tokenEntities = await tokenRepository.GetByUserIdAsync(userId);
            return tokenEntities.Select(item => item.Token).ToList();
        }
    }
}