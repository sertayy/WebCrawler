using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WebCrawler.Models;

namespace WebCrawler.Helpers
{
    public class WebCrawlerHelper
    {
        public static bool IsScraperFinished(StatusEnum status)
        {
            // TODO: Maybe add cases for other conditions
            switch (status)
            {
                case StatusEnum.Finished: return true;
            }
            return false;
        }

        public static List<Device> DeserializeJsonToDeviceList(string json)
        {
            var jsonReader = new JsonTextReader(new StringReader(json))
            {
                SupportMultipleContent = true
            };
            List<Device> devices = new();
            var jsonSerializer = new JsonSerializer();
            while (jsonReader.Read())
            {
                Device device = jsonSerializer.Deserialize<Device>(jsonReader);
                devices.Add(device);
            }
            jsonReader.Close();
            return devices;
        }
    }
}
