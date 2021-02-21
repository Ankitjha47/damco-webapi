
using Damco.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Damco.Domain
{
    public class DamcoContext : DbContext
    {
        public readonly string _connectionString;

        public DbSet<damco_supplier> damco_supplier { get; set; }
        public DbSet<damco_supplier_rate> damco_supplier_rate { get; set; }
        public DamcoContext()
        {
        }
        public DamcoContext(DbContextOptions<DamcoContext> options)
     : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var directory = Directory.GetCurrentDirectory().ToString();
                var path = Path.Combine(Directory.GetParent(directory).ToString(), "Damco.Api/appsettings.json");
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(path, false).Build();
                var connectionString = configuration.GetSection("ConnectionStrings").GetSection("Damco").Value;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<damco_supplier_rate>()
    .HasOne(e => e.damco_supplier)
    .WithMany(e => e.damco_supplier_rates)
    .HasForeignKey(e => e.fk_supplier_id)
    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
