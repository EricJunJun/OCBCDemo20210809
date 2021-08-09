using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OCBCDemo.Business.DataAccess
{
    public partial class OCBCDbContext : DbContext
    {
        public OCBCDbContext()
            : base("name=OCBCDbContext")
        {
        }

        public virtual DbSet<TransferHistory> TransferHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransferHistory>()
                .Property(e => e.TransferAmount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<User>()
                .Property(e => e.BirthDate)
                .HasPrecision(8, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.Sexy)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .HasPrecision(12, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.Balance)
                .HasPrecision(10, 2);
        }
    }
}
