using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Models;

namespace WebCrawler.Data
{
    public class DeviceEntityTypeConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.ProductType);
            builder.Property(p => p.GeoAvailability);
            builder.Property(p => p.TargetIndustries);
            builder.Property(p => p.OperatingSystems);
            builder.Property(p => p.IndustryCertifications);
            builder.Property(p => p.Description);
        }
    }
}
