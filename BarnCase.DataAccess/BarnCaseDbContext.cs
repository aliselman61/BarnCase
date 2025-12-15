using System.Data.Entity;
using BarnCase.Entities;

namespace BarnCase.DataAccess
{
    public class BarnCaseDbContext : DbContext
    {
        public BarnCaseDbContext()
            : base("name=BarnCaseDB")
        {
        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<UserMoney> UserMoney { get; set; }
        public DbSet<HashInfo> Hash { get; set; }
    }
}
