 
namespace veripark.DataAccess.Models;

public partial class TransactionsDetail
{
    
    public int Id { get; set; }
    public int? BookId { get; set; }
    public int? BorrowerId { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? DueDate { get; set; }
    public bool? IsReturned { get; set; }
    public int? MaxDate { get; set; }
    public bool? IsIssue { get; set; }
    public DateTime? OnDate { get; set; }

}