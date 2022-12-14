using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DentalClinic.Shared.Abstarctions.Repostories
{
    public abstract class GenericRepositoryBase<T, TId> : IGenericRepository<T, TId>
        where T : class
    {
        protected readonly DbSet<T> _table;
        protected readonly DbContext _context;

        public GenericRepositoryBase(DbContext context)
        {
            _context = context;
            _table = context.Set<T>();

            if (_table == null)
                throw new NullReferenceException($"DbSet for {typeof(T)} is null");
        }

        public virtual async Task AddAsync(T entity)
        {
            if (entity != null)
            {
                await _table.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(T entity)
        {
            if (entity != null)
            {
                _table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(TId id)
        {
            return await _table.FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                _table.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
