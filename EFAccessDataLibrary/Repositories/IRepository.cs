using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal interface IRepository<TKey, TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<TEntity?> GetByIdAsync(TKey id);

        Task<int> GetCountAsync();

        Task<List<TEntity>> PagingFetchAsync(int startIndex, int count);

        Task SaveAsync();
    }
}
