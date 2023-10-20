
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;
public partial class TransactionsDetailRepository : IEntityTypeConfiguration<TransactionsDetail>
{
    public void Configure(EntityTypeBuilder<TransactionsDetail> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("TransactionsDetail", "dbo");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.BookId);
        builder.Property(x => x.BorrowerId);
        builder.Property(x => x.IssueDate);
        builder.Property(x => x.DueDate);
        builder.Property(x => x.IsReturned);
        builder.Property(x => x.MaxDate);
        builder.Property(x => x.IsIssue);
        builder.Property(x => x.OnDate).HasColumnType("datetime");

    }
}
