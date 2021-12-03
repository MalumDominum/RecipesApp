using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal interface IRepository<TKey, TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<TEntity?> GetByIdAsync(TKey id);

        Task<int> GetCountAsync();

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> PagingFetchAsync(int startIndex, int count);

        Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyExistingAsync(Expression<Func<TEntity, bool>> predicate);

        Task SaveAsync();
    }
}
