using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebCrawler.Data
{
    public class WebCrawlerFactory : IDesignTimeDbContextFactory<WebCrawlerContext>
    {
        public WebCrawlerContext CreateDbContext(string[] args)  //ASK: Where to use?
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebCrawlerContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
            return new WebCrawlerContext(optionsBuilder.Options);
        }
    }
}
