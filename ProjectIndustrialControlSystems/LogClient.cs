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
        Azure.Data.Tables.TableEntity tableEntity;
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
                { "AlarmColor", alarm.AlarmColor.ToString() },
            };
            tableClient.AddEntity(tableEntity);
        }

        public async Task<IEnumerable<AlarmEntity>> GetAllAlarmsAsync()
        {
            IList<AlarmEntity> alarmList = new List<AlarmEntity>();
            TableClient tableClient = new TableClient(connectionString, "Alarms");

            var alarms = tableClient.Query<AlarmEntity>();
            foreach (var alarm in alarms)
            {
                alarmList.Add(alarm);
            }

            return alarmList;
        }

        //public List<AlarmEntity> GetActiveAlarmEntities()
        //{
        //    AlarmEntity alarmEntity;
        //    List<AlarmEntity> alarms = new List<AlarmEntity>();
        //    TableClient tableClient = new TableClient(connectionString, "Alarms");

        //    //foreach (var entity in tableClient.Query<TableEntity>())
        //    //{
        //    //    var noe = entity.Keys.
        //    //}

        //    foreach (var entity in tableClient.Query<TableEntity>())
        //    {
        //        foreach (var property in entity.Keys)
        //        {
        //            alarmEntinproperty.ElementAt(2);
        //        };
        //    }

        //    return alarms;
        //}

    }
}
