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
        public string PartitionKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string RowKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTimeOffset? ITableEntity.Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ETag ETag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Color alarmColor;

        public Color AlarmColor
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

        public AlarmEntity(string title, bool acknowledge, string timeStamp, bool state, Color alarmColor)
        {
			this.PartitionKey = title;
            this.alarmColor = alarmColor;
            this.acknowledge = acknowledge;
			this.RowKey = timeStamp;
			this.state = state;

        }
    }
}
