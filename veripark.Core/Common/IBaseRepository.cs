using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace veripark.Core.Common
{
    /// <summary>
    /// Interface defines database operations on the domain entities.
    /// </summary>
    /// <typeparam name="T">
    /// T is a Generic Entity Type this interface is only allow Class type entity.
    /// </typeparam>
    /// <remarks>
    /// None.
    /// </remarks>
    public interface IBaseRepository<T>
        where T : class
    {
        /// <summary>
        /// Adds the object to the DbSet.
        /// </summary>
        /// <param name="entity">The object.</param>
        void Add(T entity);

        /// <summary>
        /// Adds the list of T objects to the DbSet.
        /// </summary>
        /// <param name="entities">The list of objects.</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Adds the list of T objects to the DbSet.
        /// </summary>
        /// <param name="entities">The list of objects.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Removes the object from the DbSet.
        /// </summary>
        /// <param name="entity">The object.</param>
        void Remove(T entity);

        /// <summary>
        /// Removes the list of objects from the DbSet.
        /// </summary>
        /// <param name="entities">The list of objects.</param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Update and marks the object as modified in the DbSet.
        /// </summary>
        /// <param name="entity">The object.</param>
        void Update(T entity);

        /// <summary>
        /// Update and marks the object as modified in the DbSet.
        /// </summary>
        /// <param name="entity">The object.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Update the list of T objects to the DbSet.
        /// </summary>
        /// <param name="entities">The list of objects.</param>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Returns the first object of a sequence, that matching the predicate or
        /// a default value if the sequence contains no elements.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>Returns default vaule if sequence contains no elements else first elements of a sequence.</returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Returns the first object of a sequence, that matching the predicate or
        /// a default value if the sequence contains no elements.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        T FirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] navigationPropeties);

        /// <summary>
        /// Returns the first object of a sequence, that matching the predicate or
        /// a default value if the sequence contains no elements.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>Returns default vaule if sequence contains no elements else first elements of a sequence.</returns>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Returns the first object of a sequence, that matching the predicate or
        /// a default value if the sequence contains no elements.
        /// </summary>
        /// <param name="columns">The select columns list.</param>
        /// <param name="orderBy">The sort by expression.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <typeparam name="TResult">The type of the return value of the method.</typeparam>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        Task<TResult> FirstOrDefaultAsync<TResult>(
            Expression<Func<T, TResult>> columns,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] navigationPropeties)
            where TResult : class;

        /// <summary>
        /// Validates whether the entity exists that matches the specified filter.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>Returns true if exists, else false.</returns>
        bool Exists(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Validates whether the entity exists that matches the specified filter.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>Returns true if exists, else false.</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets the entites as an enumerable collection.
        /// </summary>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets the entities as an enumerable collection that matches filter specified.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets the entities as an IQueryable collection that matches the filter specified.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sort by expression.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        IQueryable<T> Find(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] navigationPropeties);

        /// <summary>
        /// Gets the entities as an IEnumerable collection that matches the filter specified.
        /// </summary>
        /// <param name="pageSize">The page size.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="totalCount">Output parameter: The total records count.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sort by expression.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        IEnumerable<T> Find(
          int pageSize,
          int pageNumber,
          out int totalCount,
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          params Expression<Func<T, object>>[] navigationPropeties);

        /// <summary>
        /// Gets the entities as an IEnumerable collection that matches the filter specified.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sort by expression.</param>
        /// <param name="coloumns">The columns to be search.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <typeparam name="TResult">The type of the return value of the method.</typeparam>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        IEnumerable<TResult> Find<TResult>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TResult>> coloumns = null,
            params Expression<Func<T, object>>[] navigationPropeties)
            where TResult : class;

        /// <summary>
        /// Gets the entities as an enumerable collection that matches filter specified.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Gets the entities as an IEnumerable collection that matches the filter specified.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sort by expression.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] navigationPropeties);

        /// <summary>
        /// Gets the entities as an IEnumerable collection that matches the filter specified.
        /// </summary>
        /// <param name="pageSize">The page size.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sort by expression.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <returns>Returns the entities as an enumerable collection and total count.</returns>
        public Task<(IEnumerable<T>, Task<long>)> FindAsync(
          int pageSize,
          int pageNumber,
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          params Expression<Func<T, object>>[] navigationPropeties);

        /// <summary>
        /// Gets the entities as an IEnumerable collection that matches the filter specified.
        /// </summary>
        /// <param name="filter">The filter expression.</param>
        /// <param name="orderBy">The sort by expression.</param>
        /// <param name="coloumns">The columns to be search.</param>
        /// <param name="navigationPropeties">The include properties.</param>
        /// <typeparam name="TResult">The type of the return value of the method.</typeparam>
        /// <returns>Returns the entities as an enumerable collection.</returns>
        Task<IEnumerable<TResult>> FindAsync<TResult>(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Expression<Func<T, TResult>> coloumns = null,
            params Expression<Func<T, object>>[] navigationPropeties)
            where TResult : class;

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