
 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;
public partial class BooksConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("Books", "dbo");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title);
        builder.Property(x => x.Isbn);
        builder.Property(x => x.Author);
        builder.Property(x => x.Publisher);
        builder.Property(x => x.MaxIssueDays);
        builder.Property(x => x.Available);
        builder.Property(x => x.OnDate).HasColumnType("datetime"); 
       

    }
}
 