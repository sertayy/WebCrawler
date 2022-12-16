using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Data;
using WebCrawler.Models;


namespace WebCrawler.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly DeviceContext _context;

        public DeviceService(DeviceContext context)
        {
            _context = context;
        }
        public void UpSertDevices(List<Device> devices)
        {
            var existingDeviceIds = new HashSet<Guid>(_context.Devices.Select(x => x.Id));

            foreach (var device in devices)
            {
                if (existingDeviceIds.Contains(device.Id))
                    _context.Entry(device).State = EntityState.Modified;
                else
                    _context.Devices.Add(device);
            }
            _context.SaveChanges();
        }
    }
}
