using System.Data.Entity;
using BarnCase.Entities;

namespace BarnCase.DataAccess
{
    public class BarnCaseDbContext : DbContext
    {
        public BarnCaseDbContext()
            : base("name=BarnCaseDb")
        {
        }

        public DbSet<UserHash> UserHashes { get; set; }
        public DbSet<UserMoney> UserMoney { get; set; }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserHash>()
                .ToTable("Hash")         

                .HasKey(x => x.UserId);

            modelBuilder.Entity<UserMoney>()
                .ToTable("UserMoney")
                .HasKey(x => x.Username);

            modelBuilder.Entity<Animal>()
                .ToTable("Animals");

            base.OnModelCreating(modelBuilder);
        }
    }
}
