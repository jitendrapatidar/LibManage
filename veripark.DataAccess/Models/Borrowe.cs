 

namespace veripark.DataAccess.Models;


public partial class Borrowe
{
    
    public int Id { get; set; }

 
  
    public string Name { get; set; }
 
    public string Contact { get; set; }

 
    public string EmailId { get; set; }

    public bool IsActive { get; set; }

 
    public DateTime? OnDate { get; set; }
}