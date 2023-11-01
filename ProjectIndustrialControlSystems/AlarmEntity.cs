using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;

namespace ProjectIndustrialControlSystems 
{
    public class AlarmEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        private string alarmColor;

        public string AlarmColor
        {
            get { return alarmColor; }
            set { alarmColor = value; }
        }

        private bool acknowledge;

		public bool Acknowledge
		{
			get { return acknowledge; }
			set { acknowledge = value; }
		}

		private bool state;

		public bool State
		{
			get { return state; }
			set { state = value; }
		}

        public AlarmEntity()
        {
            
        }

        public AlarmEntity(string title, bool acknowledge, DateTime timeStamp, bool state, Color alarmColor)
        {
			this.PartitionKey = title;
            this.alarmColor = alarmColor.ToArgb().ToString();
            this.acknowledge = acknowledge;
			this.RowKey = timeStamp.ToString();
			this.state = state;

        }
    }
}
