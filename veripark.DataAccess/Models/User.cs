 

namespace veripark.DataAccess.Models;


public partial class User
{
   
    public int Id { get; set; }

   
    public string UserName { get; set; }

    
    public string Password { get; set; }

    public string HasPassword { get; set; }

    public bool? IsActive { get; set; }

    
    public DateTime? OnDate { get; set; }
}