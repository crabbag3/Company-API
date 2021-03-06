using GlassLewis.Core;
using GlassLewis.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GlassLewis.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().ToTable("Company")
                .HasIndex(x => x.ISIN)
                .IsUnique();
        }
    }
}