 
 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;

public partial class CustomerRepository : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("Customer", "dbo");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId);
        builder.Property(x => x.NationalId);
        builder.Property(x => x.FirstName);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Gender);
        builder.Property(x => x.Age);
        builder.Property(x => x.Address);
        builder.Property(x => x.Contact);
        builder.Property(x => x.OnDate).HasColumnType("datetime");



    }
}
