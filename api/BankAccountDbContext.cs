using bankapp.Models;
// using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace bankapp
{
    public class BankDb : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }


        public BankDb(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Map entities to tables
            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");

            // Configure Primary Keys  
            modelBuilder.Entity<BankAccount>().HasKey(ug => ug.Id).HasName("PK_BankAccounts");
            // Configure indexes  
            modelBuilder.Entity<BankAccount>().HasIndex(p => p.FirstName).IsUnique().HasDatabaseName("Idx_FirstName");
            //configure columns
            modelBuilder.Entity<BankAccount>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<BankAccount>().Property(ug => ug.FirstName).HasColumnType("nvarchar(100)").IsRequired();

        }

    }
}