using System;

namespace FlameSensor.AppService.Models
{
    public class SensorReading
    {
        public string DeviceId { get; set; }
        public string SensorName { get; set; }
        public double Value { get; set; }
    }
}