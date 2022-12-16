using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace WebCrawler.Data
{
    public class DeviceFactory : IDesignTimeDbContextFactory<DeviceContext>
    {
        public DeviceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DeviceContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
            return new DeviceContext(optionsBuilder.Options);
        }
    }
}
