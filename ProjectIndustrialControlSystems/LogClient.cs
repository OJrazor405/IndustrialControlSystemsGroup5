using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using System.Configuration;
using ProjectIndustrialControlSystems.UserControls;
using System.Drawing;
using Collections.Pooled;
using System.Reflection;

namespace ProjectIndustrialControlSystems
{
    internal class LogClient
    {
        TableClient tableClient;
        TableEntity tableEntity;
        private string connectionString = ConfigurationManager.ConnectionStrings["conAlarmDB"].ConnectionString;

        public void AddAlarmEntity(string tableName, AlarmEntity alarm)
        {
            string partitionKey = alarm.PartitionKey;
            string rowKey = alarm.RowKey;
            tableClient = new TableClient(connectionString, tableName);
            tableEntity = new TableEntity(partitionKey, rowKey)
            {
                { "Acknowledged", alarm.Acknowledge },
                { "State", alarm.State },
                { "AlarmColor", alarm.AlarmColor },
            };
            tableClient.AddEntity(tableEntity);
        }

        public async Task<IEnumerable<AlarmEntity>> GetAllAlarmsAsync()
        {
            IList<AlarmEntity> alarmList = new List<AlarmEntity>();
            TableClient tableClient = new TableClient(connectionString, "Alarms");

            await Task.Run(() =>
            {
                var alarms = tableClient.Query<AlarmEntity>();
                foreach (AlarmEntity alarm in alarms)
                {
                    alarmList.Add(alarm);
                }
            });

            return alarmList;
        }
    }
}
