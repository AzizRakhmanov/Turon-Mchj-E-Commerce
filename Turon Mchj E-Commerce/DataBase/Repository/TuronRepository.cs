using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Turon_Mchj_E_Commerce.DataBase;
using Turon_Mchj_E_Commerce.DataBase.IRepository;
using Turon_Mchj_E_Commerce.Entities.Commons;

namespace Turon_Mchj_E_Commerce.Database.Repository
{
    public class TuronRepository<TEntity> : ITuronRepository<TEntity> where TEntity : Auditable
    {
        protected readonly TuronDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;
        public TuronRepository(TuronDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }
        /// <summary>
        /// Deletes first item that matched expression and keep track of it until change saved
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>true if action is successful, false if unable to delete</returns>
        public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await this.SelectAsync(expression);

            if (entity is null)
                return false;
            var entry = dbContext.Remove(entity);

            var result = entry.Context.SaveChanges();


            return result > 0 ? true : false;
        }

        /// <summary>
        /// Deletes all elements if expression matches
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool DeleteMany(Expression<Func<TEntity, bool>> expression)
        {
            var all = this.SelectAll(expression);

            if (!all.Equals(null))
            {
                this.dbSet.RemoveRange(all);

                var result = dbContext.SaveChanges();

                return result > 0;
            }
            return false;
        }

        /// <summary>
        /// Inserts element to a table and keep track of it until change saved
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            EntityEntry<TEntity> entry = await this.dbSet.AddAsync(entity);

            entry.Context.SaveChanges();

            return entry.Entity;
        }

        public async Task<bool> InsertAsync(IEnumerable<TEntity> entity)
        {
            await this.dbSet.AddRangeAsync(entity);

            var result = this.dbContext.SaveChanges();

            return result > 0 ? true : false;
        }

        /// <summary>
        /// Saves tracking changes and write them to database permenantly
        /// </summary>
        /// <returns></returns>
        public async ValueTask SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Selects all elements from table that matches condition and include relations
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
        {
            IQueryable<TEntity> query = expression is null ? this.dbSet : this.dbSet.Where(expression);

            if (includes is not null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        /// <summary>
        /// selects element from a table specified with expression and can includes relations
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
            => await this.dbSet.FirstOrDefaultAsync(expression);

        /// <summary>
        /// Updates entity and keep track of it until change saved
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            var entry = dbContext.Update(entity);

            dbContext.SaveChanges();

            return entity;
        }
    }
}