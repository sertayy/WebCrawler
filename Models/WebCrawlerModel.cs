
namespace WebCrawler.Models
{
    public class WebCrawlerModel
    {
        //public int Id { get; set; } //TODO: Maybe not necessary?
        public string RegexPattern { get; set; }
        public string Match { get; set; }
#nullable enable
        public string? Url { get; set; }
    }
}

