using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace veripark.Core.Common
{
    /// <summary>
    /// The IUnitofWork interface.
    /// </summary>
    public interface IUnitofWork
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="T">The entity type.</typeparam>
        /// <returns>The entity repository.</returns>
        IBaseRepository<T> GetBaseRepository<T>()
            where T : class;

        /// <summary>
        /// Save all changes made in the DB context.
        /// </summary>
        /// <returns>Returns number of rows affected during insert, update and delete.</returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Gets access to change tracking information and operations
        /// for a given property of the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity being tracked by the entry.</typeparam>
        /// <typeparam name="TProperty">The type of property.</typeparam>
        /// <param name="model">The entity being tracked by the entry.</param>
        /// <param name="propertyExpression">A lambda expression (t => t.Property1).</param>
        /// <returns>An object that exposes change tracking information and operations
        /// for the given property.</returns>
        PropertyEntry GetMasterDBContextPropertyEntry<TEntity, TProperty>(
            TEntity model, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class;
    }
}
