
using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;

namespace veripark.Core.Repository.Impl
{
    public class BorrowerRepository : BaseRepository<Borrowe>, IBorrowerRepository
    {
        public BorrowerRepository(LibraryManagementContext context) : base(context)
        {
        }
    }
}

