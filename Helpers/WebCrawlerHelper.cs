using System.Net.Http;
using System.Text.RegularExpressions;


namespace WebCrawler.Helpers
{
    public class WebCrawlerHelper
    {
        public static string GetHtmlCode(string url)
        {
            try
            {
                using HttpClient client = new(); //ASK: Do I have to use "using" keyword?
                using HttpResponseMessage response = client.GetAsync(url).Result;
                using HttpContent content = response.Content;
                return content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException e)
            {
                throw new KnownException($"Error occured while getting the source of the url: {e.Message}");
            }
        }

        public static string GetRegexMatches(string htmlCode, string regexPattern)
        {
            Regex regex = new (regexPattern);
            return regex.Matches(htmlCode).ToString(); //TODO: I think it should to list, check it later!!
        }
    }
}