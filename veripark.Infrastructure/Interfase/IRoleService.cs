using veripark.DataAccess.Models;
using veripark.ViewMode.Entities;

namespace veripark.Infrastructure
{
    public interface IRoleService
    {
        IEnumerable<RoleEntity> GetAll();
        RoleEntity GetById(int id);
        Int32 Save(RoleEntity obj);
        Int32 Update(int id, RoleEntity obj);
        Int32 Delete(int id);

    }
}