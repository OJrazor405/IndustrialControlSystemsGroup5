using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using System.Configuration;
using ProjectIndustrialControlSystems.UserControls;
using System.Drawing;

namespace ProjectIndustrialControlSystems
{
    internal class LogClient
    {
        TableClient tableClient;
        TableEntity tableEntity;
        private string connectionString = ConfigurationManager.ConnectionStrings["conAlarmDB"].ConnectionString;

        public void AddAlarmEntity(string entityType, AlarmEntity alarm)
        {
            string partitionKey = alarm.Title;
            string rowKey = alarm.TimeStamp.ToString();
            tableClient = new TableClient(connectionString, entityType);
            tableEntity = new TableEntity(partitionKey, rowKey)
            {
                { "Acknowledged", alarm.Acknowledge },
                { "State", alarm.State }
            };
            tableClient.AddEntity(tableEntity);
        }

        public List<AlarmEntity> GetActiveAlarmEntities()
        {
            AlarmEntity alarm;
            List<AlarmEntity> alarms = new List<AlarmEntity>();



            return alarms;
        }

    }
}
