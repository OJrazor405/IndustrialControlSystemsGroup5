using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Newtonsoft.Json;

namespace ProjectIndustrialControlSystems
{
    internal class IoTClient
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["conIoTHub"].ConnectionString;
        private static ServiceClient serviceClient;
        private static string targetDeviceId;

        public IoTClient()
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
            targetDeviceId = "piHub";
        }

        public async Task<SensorData> IoTMethodParse(string method)
        {
            var methodInvocation = new CloudToDeviceMethod(method) { ResponseTimeout = TimeSpan.FromSeconds(30) };

            var response = await serviceClient.InvokeDeviceMethodAsync(targetDeviceId, methodInvocation);

            var jsonResponse = response.GetPayloadAsJson();
            var sensorData = JsonConvert.DeserializeObject<SensorData>(jsonResponse);

            return sensorData;
        }
    }
}
