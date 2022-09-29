using ApiStone.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ApiStone.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Account>() // cria a tabela Account
               .HasOne(a => a.Balance) // Uma conta tem um saldo
               .WithOne(b => b.Account) // Um saldo tem uma conta 
               .HasForeignKey<Balance>(b => b.AccountId); // chave estrangeira

            Builder.Entity<Account>() // cria a tabela Account
                .HasMany(a => a.Deposits) // Uma conta tem muitos depósitos
                .WithOne(d => d.Account) // Um depósito tem uma conta
                .HasForeignKey(d => d.AccountId); // chave estrangeira

            Builder.Entity<Account>() // cria a tabela Account
                .HasMany(a => a.Withdraws) // Uma conta tem muitos saques
                .WithOne(w => w.Account) // Um saque tem uma conta
                .HasForeignKey(w => w.AccountId); // chave estrangeira

            Builder.Entity<Account>() // cria a tabela Account
                .HasMany(a => a.Statements) // Uma conta tem muitos extratos
                .WithOne(s => s.Account) // Um extrato tem uma conta
                .HasForeignKey(s => s.AccountId); // chave estrangeira

            Builder.Entity<Deposit>() // cria a tabela Deposit
                .HasOne(d => d.Account) // Um deposito pertence a uma conta
                .WithMany(a => a.Deposits) // Uma conta pode ter vários depositos
                .HasForeignKey(d => d.AccountId); // chave estrangeira

            Builder.Entity<Withdraw>() // cria a tabela Withdraw
                .HasOne(w => w.Account) // Um saque pertence a uma conta
                .WithMany(a => a.Withdraws) // Uma conta pode ter vários saques
                .HasForeignKey(w => w.AccountId); // chave estrangeira

            Builder.Entity<Balance>() // cria a tabela Balance
                .HasOne(b => b.Account) // Um saldo pertence a uma conta
                .WithOne(a => a.Balance) // Uma conta tem um saldo
                .HasForeignKey<Balance>(b => b.AccountId); // chave estrangeira


        }

        public DbSet<Account> Accounts { get; set; } // Accounts table
        public DbSet<Statement> Statements { get; set; } // Statements table
        public DbSet<Deposit> Deposits { get; set; } // Deposits table
        public DbSet<Withdraw> Withdraws { get; set; } // Withdraws table
        public DbSet<Balance> Balances { get; set; } // Balances table
    }
}
