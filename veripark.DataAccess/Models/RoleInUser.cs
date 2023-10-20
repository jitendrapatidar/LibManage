 

namespace veripark.DataAccess.Models;

 
public partial class RoleInUser
{
 
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }
}