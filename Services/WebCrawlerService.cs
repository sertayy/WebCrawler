using WebCrawler.Data;
using WebCrawler.Models;
using WebCrawler.Helpers;

namespace WebCrawler.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {
        private readonly WebCrawlerContext _context;

        public WebCrawlerService(WebCrawlerContext context)
        {
            _context = context;
        }

        public void Extract(WebCrawlerModel webCrawler)
        {
            string htmlCode = WebCrawlerHelper.GetHtmlCode(webCrawler.Url);
            webCrawler.Match = WebCrawlerHelper.GetRegexMatches(htmlCode, webCrawler.RegexPattern);
            _context.webCrawlers.Add(webCrawler);
            _context.SaveChanges();
        }
    }
}
