using Microsoft.EntityFrameworkCore;
using System;
using WebCrawler.Models;

namespace WebCrawler.Data
{
    public class WebCrawlerContext : DbContext
    {
        public WebCrawlerContext(DbContextOptions<WebCrawlerContext> options) : base(options)
        {
        }
        public DbSet<WebCrawlerModel> webCrawlers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new WebCrawlerEntityTypeConfiguration().Configure(modelBuilder.Entity<WebCrawlerModel>());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
