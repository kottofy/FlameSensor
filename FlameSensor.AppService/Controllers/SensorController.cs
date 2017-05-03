using FlameSensor.AppService.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.ServiceBus.Messaging;
using System.Configuration;

namespace FlameSensor.AppService.Controllers
{
    public class SensorController : ApiController
    {
        [ResponseType(typeof(SensorReading))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Unknown device.", typeof(SensorReading))]
        [SwaggerResponse(HttpStatusCode.OK, "Sensor value recorded.", typeof(SensorReading))]
        public HttpResponseMessage Post(SensorReading sensorReading)
        {
            if (!DoesDeviceAlreadyExist(sensorReading.DeviceId))
            {
                return Request.CreateResponse<SensorReading>(HttpStatusCode.NotFound, sensorReading);
            }

            SaveReading(sensorReading);

            // Send notification - Flame detected
            try
            {
                var connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

                var queueName = "flamesensorqueue";

                var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
                var message = new BrokeredMessage("Flame detected!");
                client.Send(message);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return Request.CreateResponse<SensorReading>(HttpStatusCode.OK, sensorReading);
        }

    private bool DoesDeviceAlreadyExist(string deviceId)
        {
            // todo: implement
            return true;
        }

        private bool SaveReading(SensorReading sensorReading)
        {
            // todo: implement
            return true;
        }

    }
}




