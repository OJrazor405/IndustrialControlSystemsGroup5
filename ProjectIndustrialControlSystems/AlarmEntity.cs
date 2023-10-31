using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace ProjectIndustrialControlSystems 
{
    public class AlarmEntity
    {
		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

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

		private DateTime timeStamp;

		public DateTime TimeStamp
		{
			get { return timeStamp; }
			set { timeStamp = value; }
		}

		private bool state;

		public bool State
		{
			get { return state; }
			set { state = value; }
		}

        public AlarmEntity(string title, bool acknowledge, DateTime timeStamp, bool state, Color alarmColor)
        {
			this.title = title;
            this.alarmColor = alarmColor;
            this.acknowledge = acknowledge;
			this.timeStamp = timeStamp;
			this.state = state;

        }
    }
}
