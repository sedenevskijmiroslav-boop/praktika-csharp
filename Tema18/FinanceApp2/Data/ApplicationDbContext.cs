using Microsoft.EntityFrameworkCore;
using FinanceApp2.Models;

namespace FinanceApp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "FinanceApp2",
                "finance.db");

            var directory = System.IO.Path.GetDirectoryName(dbPath);
            if (!System.IO.Directory.Exists(directory))
                System.IO.Directory.CreateDirectory(directory);

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Reminder>().HasKey(r => r.Id);
            modelBuilder.Entity<Message>().HasKey(m => m.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}