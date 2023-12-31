﻿using System;
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
using Eco.UmlRt;

namespace ProjectIndustrialControlSystems
{
    internal class LogClient
    {
        TableClient tableClient;
        TableEntity tableEntity;
        private string connectionString = ConfigurationManager.ConnectionStrings["conAlarmDB"].ConnectionString;

        public void AddAlarmEntity(AlarmEntity alarm)
        {
            string partitionKey = alarm.PartitionKey;
            string rowKey = alarm.RowKey;
            tableClient = new TableClient(connectionString, "Alarms");
            tableEntity = new TableEntity(partitionKey, rowKey)
            {
                { "Acknowledged", alarm.Acknowledged },
                { "State", alarm.State },
                { "AlarmColor", alarm.AlarmColor },
            };
            tableClient.AddEntity(tableEntity);
        }

        public async Task<IEnumerable<AlarmEntity>> GetAllAlarmsAsync()
        {
            TableClient tableClient = new TableClient(connectionString, "Alarms");
            IList<AlarmEntity> alarmList = new List<AlarmEntity>();

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

        public async Task<string> UpdateAlarm(AlarmEntity alarm)
        {
            TableClient tableClient = new TableClient(connectionString, "Alarms");

            await tableClient.UpsertEntityAsync(alarm);

            return "Alarm is updated";
        }

        public async Task<string> DeleteAlarm(AlarmEntity alarm)
        {
            TableClient tableClient = new TableClient(connectionString, "Alarms");

            await tableClient.DeleteEntityAsync(alarm.PartitionKey, alarm.RowKey);

            return "Alarm is deleted";
        }
    }
}
