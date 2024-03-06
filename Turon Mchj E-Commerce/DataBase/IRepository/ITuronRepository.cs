using System.Linq.Expressions;
using Turon_Mchj_E_Commerce.Entities.Commons;

namespace Turon_Mchj_E_Commerce.DataBase.IRepository
{
    public interface ITuronRepository<TEntity> where TEntity : Auditable
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);

        Task<bool> InsertAsync(IEnumerable<TEntity> entity);

        TEntity Update(TEntity entity);
        IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
        ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
        ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        bool DeleteMany(Expression<Func<TEntity, bool>> expression);

        ValueTask SaveAsync();
    }
}
