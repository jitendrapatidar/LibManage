 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;
public partial class RoleInUserConfiguration : IEntityTypeConfiguration<RoleInUser>
{
    public void Configure(EntityTypeBuilder<RoleInUser> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("RoleInUser", "dbo");
        builder.HasKey(x => x.Id);


    }
}
 