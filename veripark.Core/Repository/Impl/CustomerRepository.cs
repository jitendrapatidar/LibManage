

using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;

namespace veripark.Core.Repository.Impl;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(LibraryManagementContext context) : base(context)
    {
    }
}
