using System;
using System.Collections.Generic;

namespace WebCrawler.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
#nullable enable
        public string? ProductType { get; set; }
        public string? GeoAvailability { get; set; }
        public string? TargetIndustries { get; set; }
        public string? OperatingSystems { get; set; }
        public string? IndustryCertifications { get; set; }
        public string? Description { get; set; }
    }
#nullable disable

    public class Devices
    {
        public List<Device> DeviceModels { get; set; }
    }
}