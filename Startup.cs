using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebCrawler;
using WebCrawler.Data;
using WebCrawler.Services;

[assembly: WebJobsStartup(typeof(Startup))]
namespace WebCrawler
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddDbContext<DeviceContext>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
        }
    }
}