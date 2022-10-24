using ApiStone.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiStone.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Account>()
                .HasMany(a => a.Operations)
                .WithOne(o => o.Account)
                .HasForeignKey(o => o.AccountId);


        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
