using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace TodoPwa.DAL.Repositories
{
    public class RepositoryBase<TEntity, TKey> : EntityFrameworkRepository<TEntity, TKey, AppDbContext>
        where TEntity : class, IEntity<TKey>, new()
    {
        public RepositoryBase(IUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }
    }
}