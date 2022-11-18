using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Models;

namespace WebCrawler.Data
{
    public class WebCrawlerEntityTypeConfiguration : IEntityTypeConfiguration<WebCrawlerModel>
    {
        public void Configure(EntityTypeBuilder<WebCrawlerModel> builder)
        {
            //builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Url).IsRequired();
            builder.Property(p => p.RegexPattern).IsRequired();
            builder.Property(p => p.Match).IsRequired();
        }
    }
}
