
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using veripark.DataAccess.Models;

namespace veripark.DataAccess.Configuration;

public partial class HolidayMasterRepository : IEntityTypeConfiguration<HolidayMaster>
{
    public void Configure(EntityTypeBuilder<HolidayMaster> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        builder.ToTable("HolidayMaster", "dbo");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.HolidayTitle);
        builder.Property(x => x.HolidayFromDate);
        builder.Property(x => x.HolidayToDate);
        builder.Property(x => x.Description);
        builder.Property(x => x.IsActive);
        builder.Property(x => x.OnDate).HasColumnType("datetime");

    }
}
 