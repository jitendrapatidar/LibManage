using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;

namespace veripark.Core.Repository.Impl

{
    public class BookRepository : BaseRepository<Books>, IBookRepository
    {
        public BookRepository(LibraryManagementContext context) : base(context)
        {
        }
    }

    
}



