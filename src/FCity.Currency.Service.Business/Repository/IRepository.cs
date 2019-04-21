using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace FCity.Currency.Service.Business.Service
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<int> InsertListAsync(IEnumerable<TEntity> entityList);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> UpdateListAsync(IEnumerable<TEntity> entityList);
        Task<TEntity> UpdateWithoutSelect(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<int> DeleteRange(IEnumerable<TEntity> entityList);
        bool Exist(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetListAsync();
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetListAsync<TKey>(Expression<Func<TEntity, TKey>> sortExpression, bool isDesc);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> GetLastAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> sortExpression, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TKey>> GetListColumnDistinctAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> columnProperty);
        Task<List<TResult>> GetSelectListAsync<TResult>(Expression<Func<TEntity, TResult>> selector);
        Task<List<TResult>> GetSelectListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector);

        DbSet<TEntity> Query();
        TEntity InsertWithoutCommit(TEntity entity);
        TEntity UpdateWithoutCommit(TEntity entity);
        bool DeleteWithoutCommit(TEntity entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
