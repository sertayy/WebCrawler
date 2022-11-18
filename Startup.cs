using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebCrawler.Data;
using WebCrawler.Services;
using WebCrawler;

[assembly: WebJobsStartup(typeof(Startup))]
namespace WebCrawler
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddDbContext<WebCrawlerContext>();
            builder.Services.AddScoped<IWebCrawlerService, WebCrawlerService>();
        }
    }
}