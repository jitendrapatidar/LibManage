using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace veripark.Core.Common
{
    /// <summary>
    /// MasterBaseRepository class to perform basic or common database operations on the domain entities.
    /// </summary>
    /// <typeparam name="T">
    ///  Generic Entity Type Where it allow only entity Class.
    /// </typeparam>
    /// <remarks>
    /// None.
    /// </remarks>
    public class BaseRepository<T>
        : IBaseRepository<T>
        where T : class
    {
        private readonly DbSet<T> dbset;

        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">
        /// Create a object of CreditSeviceMasterContext.
        /// </param>
        public BaseRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this._context = context;
            this.dbset = context.Set<T>();
        }

        /// <inheritdoc/>
        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        /// <inheritdoc/>
        public async Task AddAsync(T entity)
        {
            await this._context.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public void AddRange(IEnumerable<T> entities)
        {
            this._context.Set<T>().AddRange(entities);
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await this._context.Set<T>().AddRangeAsync(entities).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        /// <inheritdoc/>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            this._context.Set<T>().RemoveRange(entities);
        }

        /// <inheritdoc/>
        public void Update(T entity)
        {
            this._context.Attach(entity);
            EntityEntry<T> entry = _context.Entry(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(T entity)
        {
            this._context.Attach(entity);
            EntityEntry<T> entry = _context.Entry(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this._context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().Where(predicate).FirstOrDefault();
        }

        /// <inheritdoc/>
        public virtual T FirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] navigationPropeties)
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
            }

            return dbquery.FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().Where(predicate).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<TResult> FirstOrDefaultAsync<TResult>(
            Expression<Func<T, TResult>> columns,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] navigationPropeties)
            where TResult : class
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
            }

            if (orderBy != null)
            {
                dbquery = orderBy(dbquery);
            }

            return await dbquery.Select(columns).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> GetAll()
        {
            return this._context.Set<T>();
        }

        /// <inheritdoc/>
        public bool Exists(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().Any(predicate);

        /// <inheritdoc/>
        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().AnyAsync(predicate);

        /// <inheritdoc/>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this._context.Set<T>().Where(predicate);
        }

        /// <inheritdoc/>
        public virtual IQueryable<T> Find(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] navigationPropeties)
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> property in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(property);
                }
            }

            if (orderBy != null)
            {
                dbquery = orderBy(dbquery);
            }

            return dbquery;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> Find(
            int pageSize,
            int pageNumber,
            out int totalCount,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] navigationPropeties)
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
            }

            if (orderBy != null)
            {
                dbquery = orderBy(dbquery);
            }

            totalCount = dbquery.Count();

            dbquery = dbquery.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return dbquery.ToList();
        }

        /// <inheritdoc/>
        public IEnumerable<TType> Find<TType>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TType>> coloumns = null,
            params Expression<Func<T, object>>[] navigationPropeties)
               where TType : class
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
            }

            if (orderBy != null)
            {
                dbquery = orderBy(dbquery);
            }

            return dbquery.Select(coloumns).ToList();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await this._context.Set<T>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] navigationPropeties)
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> property in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(property);
                }
            }

            if (orderBy != null)
            {
                dbquery = orderBy(dbquery);
            }

            return await dbquery.ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<(IEnumerable<T>, Task<long>)> FindAsync(
            int pageSize,
            int pageNumber,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] navigationPropeties)
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
            }

            if (orderBy != null)
            {
                dbquery = orderBy(dbquery);
            }

            dbquery = dbquery.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return (await dbquery.ToListAsync().ConfigureAwait(false), dbquery.LongCountAsync());
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TResult>> FindAsync<TResult>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TResult>> coloumns = null,
            params Expression<Func<T, object>>[] navigationPropeties)
            where TResult : class
        {
            IQueryable<T> dbquery = this.dbset;

            if (filter != null)
            {
                dbquery = dbquery.Where(filter);
            }

            if (navigationPropeties != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in navigationPropeties)
                {
                    dbquery = dbquery.Include<T, object>(navigationProperty);
                }
            }

            if (orderBy != null)
            {
                dbquery = orderBy(dbquery);
            }

            return await dbquery.Select(coloumns).ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public PropertyEntry GetMasterDBContextPropertyEntry<TEntity, TProperty>(
            TEntity model, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class
        {
            return _context.Entry(model).Property(propertyExpression);
        }

        /// <inheritdoc/>
        public void UpdateRange(IEnumerable<T> entities)
        {
            this._context.Set<T>().UpdateRange(entities);
        }
    }

    
}
