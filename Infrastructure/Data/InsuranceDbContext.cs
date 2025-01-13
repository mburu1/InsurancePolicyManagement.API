using InsurancePolicyManagement.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace InsurancePolicyManagement.API.Infrastructure.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }
        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>().HasKey(p => p.Id);
            modelBuilder.Entity<Policy>().Property(p => p.PolicyNumber).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Policy>().Property(p => p.Premium).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Policy>()
            .HasIndex(u => u.PolicyNumber)
            .IsUnique(); // Makes the index unique
        }
    }
}
