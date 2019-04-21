using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Logging;
using FCity.Currency.Service.Business.Service;
using FCity.Currency.Service.Api;

namespace FCity.Currency.Service.Business.Service
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public class Repository<TEntity> : IRepository<TEntity>
            where TEntity : class, new()
    {
        #region Initializer
        private readonly CurrencyContex _context;
        private readonly ILogger<Repository<TEntity>> logger;
        private DbSet<TEntity> _entities;
        private static EventId _eventId = new EventId(960103, "ChangeTrack");
        public Repository(
            CurrencyContex context,
            ILogger<Repository<TEntity>> logger)
        {
            _context = context;
            this.logger = logger;
            _entities = context.Set<TEntity>();
        }

        private DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }
                return _entities;
            }
        }
        #endregion

        #region Methods

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.Entities.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(predicate);
        }

        public async virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.Entities.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<int> InsertListAsync(IEnumerable<TEntity> entityList)
        {
            _context.Set<TEntity>().AddRange(entityList);
            var efectedRows = await _context.SaveChangesAsync();
            return efectedRows;
        }

        public virtual TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            var entry = _context.Entry<TEntity>(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<int> UpdateListAsync(IEnumerable<TEntity> entityList)
        {
            _context.Set<TEntity>().AttachRange(entityList);
            foreach (var entity in entityList)
            {
                var entry = _context.Entry<TEntity>(entity);
                entry.State = EntityState.Modified;
            }

            var entityCahngeTrackerLog = _context;// This method must be called before 'SaveChanges' 
            var efectedRows = await _context.SaveChangesAsync();
            return efectedRows;
        }

        public async virtual Task<TEntity> UpdateWithoutSelect(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async virtual Task<bool> Delete(TEntity entity)
        {
            try
            {
                Entities.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async virtual Task<int> DeleteRange(IEnumerable<TEntity> entityList)
        {
            Entities.RemoveRange(entityList);
            var effectedRows = await _context.SaveChangesAsync();
            return effectedRows;
        }

        public virtual bool Exist(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Entities.Any(predicate);
        }

        public async virtual Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Entities.AnyAsync(predicate);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.Entities.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList<TEntity>();
        }

        public virtual Task<List<TEntity>> GetListAsync()
        {
            return Entities.AsNoTracking().ToListAsync<TEntity>();
        }

        public async virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.Entities.Where(predicate);
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync<TEntity>();
        }

        public Task<List<TEntity>> GetListAsync<TKey>(Expression<Func<TEntity, TKey>> sortExpression, bool isDesc)
        {
            return isDesc
                ? this.Entities.AsNoTracking().OrderByDescending(sortExpression).ToListAsync()
                : this.Entities.AsNoTracking().OrderBy(sortExpression).ToListAsync();
        }


        public async virtual Task<TEntity> GetLastAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> sortExpression, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.Entities.AsQueryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.OrderBy(sortExpression).LastOrDefaultAsync(predicate);
        }

        public async virtual Task<List<TKey>> GetListColumnDistinctAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> columnProperty)
        {
            return await this.Entities.Where(predicate).Select(columnProperty).Distinct().ToListAsync();
        }

        /// <summary>
        /// Return view model list by projection
        /// </summary>
        public virtual Task<List<TResult>> GetSelectListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            var query = this.Entities.AsNoTracking().Where(predicate);
            return query.Select(selector).ToListAsync();
        }


        public Task<List<TResult>> GetSelectListAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return this.Entities.AsNoTracking().Select(selector).ToListAsync();
        }

        public DbSet<TEntity> Query()
        {
            return this.Entities;
        }
        /// <summary>
        /// Save all changes to db in a single transaction.
        /// </summary>
        /// <returns>
        /// Return number of state entries written to the database.s
        /// </returns>
        /// <Remarks>
        /// You don't have to create TransactionScope. By default, (if the database provider supports transactions) all changes in a single call to SaveChanges() are applied in a transaction.
        /// If any of the changes fail, then the transaction is rolled back and none of the changes are applied to the database. 
        /// This means that SaveChanges() is guaranteed to either completely succeed, or leave the database unmodified if an error occurs.
        /// By using explicit transactions in EF, you change that behavior and force every CRUD operation during a transaction scope to be executed in serializable isolation mode
        /// which is the highest and most blocking type. 
        /// No process will be able to access the tables you have touched (even reading from it) during your transaction. 
        /// That can lead to Deadlocks pretty fast and you want to avoid them at all costs!
        /// https://docs.microsoft.com/en-us/ef/core/saving/transactions
        /// </Remarks>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }

        public virtual TEntity InsertWithoutCommit(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }
        public virtual TEntity UpdateWithoutCommit(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            return entity;
        }
        public virtual bool DeleteWithoutCommit(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return true;
        }
        #endregion

        private void LogChangeTracks(string entityCahngeTrackerLog)
        {
            using (logger.BeginScope("{@ChangeTrack}", entityCahngeTrackerLog))
            {
                logger.LogInformation(_eventId, "SaveChangesAsync");
            }
        }
    }

}
