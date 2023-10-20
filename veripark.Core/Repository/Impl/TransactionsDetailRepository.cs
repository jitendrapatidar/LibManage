
using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;
namespace veripark.Core.Repository.Impl;
public partial class TransactionsDetailRepository :
 BaseRepository<TransactionsDetail>, ITransactionsDetailRepository
{
    public TransactionsDetailRepository(LibraryManagementContext context) : base(context)
    {
    }
}
