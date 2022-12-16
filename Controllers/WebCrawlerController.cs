using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebCrawler.Helpers;
using WebCrawler.Models;
using WebCrawler.Services;

namespace WebCrawler
{
    public class WebCrawlerController
    {
        private readonly ILogger<WebCrawlerController> _logger;
        private readonly IDeviceService _deviceService;
        private readonly HttpClient _client;
        public WebCrawlerController(ILogger<WebCrawlerController> log, IDeviceService deviceService)
        {
            _logger = log;
            _deviceService = deviceService;
            _client = new HttpClient();
        }

        [FunctionName("SaveDevices")]
        [OpenApiOperation(operationId: "SaveDevices", tags: new[] { "SaveDevices" })]
        [OpenApiRequestBody("application/json", typeof(Notification), Description = "JSON request body containing notification details.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> SaveDevices(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Notification notificationModel = JsonConvert.DeserializeObject<Notification>(requestBody);
                _logger.LogInformation($"Received notification from the sitemap/scrapingJobId: {notificationModel.SitemapName}/{notificationModel.ScrapingJobId}");

                if (WebCrawlerHelper.IsScraperFinished(notificationModel.Status))
                {
                    HttpResponseMessage response = GetAllDevices(notificationModel.ScrapingJobId);
                    if (response.IsSuccessStatusCode)
                    {
                        List<Device> devices = WebCrawlerHelper.DeserializeJsonToDeviceList(response.Content.ReadAsStringAsync().Result);
                        _deviceService.UpSertDevices(devices);
                    }
                    else
                    {
                        _logger.LogError($"Http response of the getAllDevices endpoint returned: {response.StatusCode}");
                    }
                }
                else
                {
                    _logger.LogWarning($"Scraper is not finished. Status: {notificationModel.Status}");
                }
                return new OkObjectResult(new { Message = "Device information saved successfully!" });
            }
            catch (KnownException)
            {
                _logger.LogError("An error occured while deleting the student!");
                throw;
            }
        }

        private HttpResponseMessage GetAllDevices(int scrapingJobId)
        {
            return _client.GetAsync($"https://api.webscraper.io/api/v1/scraping-job/{scrapingJobId}/json?api_token={Environment.GetEnvironmentVariable("ApiToken")}").Result;
        }
    }
}