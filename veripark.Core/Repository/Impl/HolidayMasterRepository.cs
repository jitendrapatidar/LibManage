
using veripark.Core.Common;
using veripark.DataAccess;
using veripark.DataAccess.Models;
using veripark.Core.Repository.Interface;

namespace veripark.Core.Repository.Impl;

public partial class HolidayMasterRepository : BaseRepository<HolidayMaster> , IHolidayMasterRepository
{
    public HolidayMasterRepository(LibraryManagementContext context) : base(context)
    {
    }
}
 