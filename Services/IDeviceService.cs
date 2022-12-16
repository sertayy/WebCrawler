using System.Collections.Generic;
using WebCrawler.Models;

namespace WebCrawler.Services
{
    public interface IDeviceService
    {
        void UpSertDevices(List<Device> devices);
    }
}
