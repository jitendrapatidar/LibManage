 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;
public partial class BorrowerConfiguration : IEntityTypeConfiguration<Borrowe>
{
    public void Configure(EntityTypeBuilder<Borrowe> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("Borrower", "dbo");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Contact);
        builder.Property(x => x.EmailId);
        builder.Property(x => x.IsActive);
        builder.Property(x => x.OnDate).HasColumnType("datetime");


    }
}

