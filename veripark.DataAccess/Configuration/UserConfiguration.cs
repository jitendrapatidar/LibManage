using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;
public partial class UserRepository : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("User", "dbo");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserName);
        builder.Property(x => x.Password);
        builder.Property(x => x.HasPassword);
        builder.Property(x => x.IsActive);
        builder.Property(x => x.OnDate).HasColumnType("datetime");


    }
}
 