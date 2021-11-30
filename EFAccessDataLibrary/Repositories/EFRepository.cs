﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAccessLayer.Repositories;

using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public abstract class EFRepository<TKey, TEntity, TContext> : IRepository<TKey, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected EFRepository(TContext context) { Context = context; }

        protected TContext Context { get; }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var item = await Context.Set<TEntity>().AddAsync(entity);
            return item.Entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Task.FromResult(0);
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            return Context.Set<TEntity>()
                          .Remove(entity).Entity;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>()
                                .ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await Context.Set<TEntity>()
                                .FindAsync(id);
        }

        public virtual async Task<int> GetCountAsync()
        {
            return await Context.Set<TEntity>()
                                .CountAsync();
        }

        public virtual async Task<List<TEntity>> PagingFetchAsync(int startIndex, int count)
        {
            return await Context.Set<TEntity>()
                                .Take(startIndex..count)
                                .ToListAsync();
        }

        public Task SaveAsync() => Context.SaveChangesAsync();
    }
}