using Microsoft.EntityFrameworkCore;
using System;
using WebCrawler.Models;

namespace WebCrawler.Data
{
    public class DeviceContext : DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {
        }
        public DbSet<Device> Devices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new DeviceEntityTypeConfiguration().Configure(modelBuilder.Entity<Device>());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
