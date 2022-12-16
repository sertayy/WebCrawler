using Newtonsoft.Json;

namespace WebCrawler.Models
{
    public class Notification
    {
        [JsonProperty(PropertyName = "scrapingjob_id")]
        public int ScrapingJobId { get; set; }
        public StatusEnum Status { get; set; }
        [JsonProperty(PropertyName = "sitemap_id")]
        public int SitemapId { get; set; }
        [JsonProperty(PropertyName = "sitemap_name")]
        public string SitemapName { get; set; }
#nullable enable
        [JsonProperty(PropertyName = "custom_id")]
        public string? CustomId { get; set; }
    }
}
