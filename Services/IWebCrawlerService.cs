using WebCrawler.Models;

namespace WebCrawler.Services
{
    public interface IWebCrawlerService
    {
        void Extract(WebCrawlerModel webCrawler);
    }
}
