using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace veripark.Core.Common
{
    /// <summary>
    /// Represents Unit of Work.
    /// </summary>
    /// <typeparam name="TDbcontext">The Db Context.</typeparam>
    public class UnitofWork<TDbcontext> : IUnitofWork, IDisposable
        where TDbcontext : DbContext, IDisposable
    {
        private readonly TDbcontext _dbcontext;

        private readonly bool _disposed;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitofWork{TDbcontext}"/> class.
        /// </summary>
        /// <param name="dbcontext">The Db context.</param>
        public UnitofWork(TDbcontext dbcontext)
        {
            this._dbcontext = dbcontext;
            this._disposed = false;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public IBaseRepository<T> GetBaseRepository<T>()
            where T : class
        {
            if (this.repositories.TryGetValue(typeof(T), out var repo))
            {
                return (IBaseRepository<T>)repo;
            }

            object repository = new BaseRepository<T>(this._dbcontext);
            this.repositories.Add(typeof(T), repository);
            return (IBaseRepository<T>)repository;
        }

        /// <inheritdoc/>
        public async Task<int> SaveAsync()
        {
            return await this._dbcontext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public Microsoft.EntityFrameworkCore.ChangeTracking.PropertyEntry GetMasterDBContextPropertyEntry<TEntity, TProperty>(
            TEntity model, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class
        {
            return _dbcontext.Entry(model).Property(propertyExpression);
        }

        /// <summary>
        /// Releases all Dbcontext resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to dispose allocated resources; otherwise <c>false</c>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                this._dbcontext.Dispose();
            }
        }
    }
}
