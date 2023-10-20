 

namespace veripark.DataAccess.Models;


public partial class Customer
{
 
    public int Id { get; set; }

    public int UserId { get; set; }

    public int NationalId { get; set; }

 
    public string FirstName { get; set; }

  
    public string LastName { get; set; }

    
    public string Gender { get; set; }

    public int? Age { get; set; }

 
    public string Address { get; set; }

 
    public string Contact { get; set; }
     
    public DateTime? OnDate { get; set; }
}