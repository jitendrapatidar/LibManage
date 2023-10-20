 

namespace veripark.DataAccess.Models;


public partial class HolidayMaster
{
 
    public int Id { get; set; }

  
    public string HolidayTitle { get; set; }

     
    public DateTime? HolidayFromDate { get; set; }

 
    public DateTime? HolidayToDate { get; set; }

 
    public string Description { get; set; }

    public bool? IsActive { get; set; }

 
    public DateTime? OnDate { get; set; }
}