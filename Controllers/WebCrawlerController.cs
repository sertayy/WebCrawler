using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using WebCrawler.Models;
using WebCrawler.Services;

namespace WebCrawler
{
    public class WebCrawlerController
    {
        private readonly ILogger<WebCrawlerController> _logger;
        private readonly IWebCrawlerService _webCrawlerService;
        public WebCrawlerController(ILogger<WebCrawlerController> log, IWebCrawlerService webCrawlerService)
        {
            _logger = log;
            _webCrawlerService = webCrawlerService;
        }

        [FunctionName("SaveMatches")]
        [OpenApiOperation(operationId: "SaveMatches", tags: new[] { "SaveMatches" })]
        [OpenApiRequestBody("application/json", typeof(WebCrawlerModel), Description = "JSON request body containing {regex pattern, url}")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> SaveMatches(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                WebCrawlerModel data = JsonConvert.DeserializeObject<WebCrawlerModel>(requestBody);
                _logger.LogInformation($"Extracting information from the url: {data.Url}");
                _webCrawlerService.Extract(data);
                return new OkObjectResult(new { Message = "Information Saved SuccessFully", Data = data });
            }
            catch
            {
                _logger.LogError("An error occured while extracting information.");
                throw;
            }
        }
    }
}