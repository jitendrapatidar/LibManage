 
namespace veripark.DataAccess.Models;


public partial class Books
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public int? MaxIssueDays { get; set; }
    public bool? Available { get; set; }
    public DateTime? OnDate { get; set; }


}