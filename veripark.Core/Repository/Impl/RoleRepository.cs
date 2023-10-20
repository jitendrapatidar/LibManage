

using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;
namespace veripark.Core.Repository.Impl;
public partial class RoleRepository : 
  BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(LibraryManagementContext context) : base(context)
    {
    }
}
