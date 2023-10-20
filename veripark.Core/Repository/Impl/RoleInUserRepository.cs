

using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;

namespace veripark.Core.Repository.Impl;
public partial class RoleInUserRepository : BaseRepository<RoleInUser>, IRoleInUserRepository
{
    public RoleInUserRepository(LibraryManagementContext context) : base(context)
    {
    }
}

