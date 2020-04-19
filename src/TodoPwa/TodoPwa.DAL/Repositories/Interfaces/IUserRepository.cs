using System.Threading.Tasks;
using TodoPwa.DAL.Entities;

namespace TodoPwa.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByUsernameAsync(string username);
    }
}