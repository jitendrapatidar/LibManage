
using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;
namespace veripark.Core.Repository.Impl;
public partial class UserRepository :  
 BaseRepository<User>, IUserRepository
{
    public UserRepository(LibraryManagementContext context) : base(context)
    {
    }
}