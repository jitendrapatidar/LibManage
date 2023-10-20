
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using veripark.ConfigurationSettings;
using veripark.DataAccess;
namespace veripark.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {

        protected LibraryManagementContext libraryManagementContext;
        public UnitofWork() {

            var LmsDbContextOption = new DbContextOptionsBuilder<LibraryManagementContext>()
                .UseSqlServer(ConnectionString.dbConnectionString)
                .Options;

            this.libraryManagementContext = new LibraryManagementContext(LmsDbContextOption);
        }

        public void Dispose() { }

        public PropertyEntry GetLmsDbContextPropertyEntry<TEntry, TProperty>(
            TEntry model, Expression<Func<TEntry, TProperty>> propertyExpression)
            where TEntry : class
        {

            return libraryManagementContext.Entry(model).Property(propertyExpression);

        }

        public Int32 Save() {

            return this.libraryManagementContext.SaveChanges();
        }
        public async Task<Int32> SaveAsync()
        {

            return await this.libraryManagementContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public void BulkInsert<TEntry>(List<TEntry> model) 
            where TEntry : class
        {
            libraryManagementContext.BulkInsert(model);
        }
        public async void BulkInsertAsync<TEntry>(List<TEntry> model)
           where TEntry : class
        {
            await libraryManagementContext.BulkInsertAsync(model).ConfigureAwait(false);
        }
        // static Task BulkInsertAsync
    }
    public interface IUnitofWork :IDisposable
    {
        Int32 Save();
        Task<Int32> SaveAsync();
        void BulkInsert<TEntry>(List<TEntry> model)
            where TEntry:class;
        void BulkInsertAsync<TEntry>(List<TEntry> model)
            where TEntry : class;
    }
}
