using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebCrawler.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusEnum
    {
        WaitingToBeScheduled,   // the scraping job is waiting in a queue to be scraped
        Scheduled,              // the scraping job is waiting for the scraper server and will start in a moment
        Started,                // the scraping job is in motion;
        Failed,                 // the website returned more than 50% 4xx or 50xx responses or there were network errors, which means that job execution was stopped and scraping job marked as failed; however, the user can continue it manually
        Finished,               // the scraping job has completed successfully without any failed or empty pages
        Shelved,                // the scraping job has been moved to cold storage, meaning that either it stopped and then was moved to cold storage or it finished with empty or failed pages. This status will be removed in a future release
        Stopped                 // stopped 
    }
}
