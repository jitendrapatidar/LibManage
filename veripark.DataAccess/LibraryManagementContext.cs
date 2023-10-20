
#nullable disable
using Microsoft.EntityFrameworkCore;
using veripark.DataAccess.Models;

namespace veripark.DataAccess
{
    public partial class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }

        public virtual DbSet<Borrowe> Borrower { get; set; }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<HolidayMaster> HolidayMaster { get; set; }

        public virtual DbSet<Role> Role { get; set; }

        public virtual DbSet<RoleInUser> RoleInUser { get; set; }

        public virtual DbSet<TransactionsDetail> TransactionsDetail { get; set; }

        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUseProfile");

                entity.Property(e => e.Gender).IsFixedLength();
            });

            modelBuilder.Entity<HolidayMaster>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }

}