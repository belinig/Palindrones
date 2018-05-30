using System;
using System.Linq;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataAccess
{
    public class PalindronesDbContext : DbContext, IPalindronesData
    {
        public DbSet<Palindrone> PalindroneItems { get; set; }


        public PalindronesDbContext(DbContextOptions<PalindronesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //modelBuilder.Entity<TradeHistoryItem>().HasKey(lc => new { lc.Symbol, lc.ExchangeAbbr, lc.Date });
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //                            .SelectMany(t => t.GetProperties())
            //                            .Where(p => p.ClrType == typeof(decimal))
            //         )
            //{
            //    property.Relational().ColumnType = "decimal(18, 4)";
            //}

            //modelBuilder.Entity<TradeHistoryItem>().ToTable("TradeHistory");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public void Add(string item)
        {
            PalindroneItems.Add(new Palindrone() { Text = item});
            this.SaveChanges();
        }

        public IQueryable<string> Get()
        {
            return this.PalindroneItems.Select(x => x.Text);
        }
        
    }
}

