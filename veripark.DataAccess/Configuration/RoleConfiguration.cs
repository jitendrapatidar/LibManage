 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;
public partial class RoleRepository : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("Role", "dbo");
        builder.HasKey(x => x.Id);

    }
}
 