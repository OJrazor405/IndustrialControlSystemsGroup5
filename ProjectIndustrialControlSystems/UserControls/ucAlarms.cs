using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices;
using ProjectIndustrialControlSystems.UserControls;


namespace ProjectIndustrialControlSystems.UserControls
{
    public partial class ucAlarms : UserControl
    {
        LogClient logClient = new LogClient();
        List<AlarmEntity> alarmList;
        AlarmEntity alarmEntity;

        public ucAlarms()
        {
            InitializeComponent();
            InitializeListView();
            InitializeLogger();
        }

        private void InitializeListView()
        {
            lvAlarm.View = View.Details;
            lvAlarm.CheckBoxes = true;
            lvAlarm.FullRowSelect = true;
            lvAlarm.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvAlarm.OwnerDraw = true;

            //Add colums to the listview
            lvAlarm.Columns.Add("Alarm Items", 200, HorizontalAlignment.Left);
            lvAlarm.Columns.Add("Timestamp", 200, HorizontalAlignment.Left);
            lvAlarm.Columns.Add("Acknowledged", 120, HorizontalAlignment.Left);

            //Draws items to the listview
            lvAlarm.DrawItem += LvAlarm_DrawItem;
            lvAlarm.DrawSubItem += LvAlarm_DrawSubItem;
            lvAlarm.DrawColumnHeader += LvAlarm_DrawColumnHeader;
        }

        private async void InitializeLogger()
        {
            while (true)
            {
                await AppendAlarmsAsync();
            }
        }

        public async Task AppendAlarmsAsync()
        {
            // Calling GetAllAlarmsAsync and storing the values in a list
            IEnumerable<AlarmEntity> alarms = await logClient.GetAllAlarmsAsync();
            alarmList = alarms.ToList();
            List<ListViewItem> list = new List<ListViewItem>();
            int numDBAlarms = alarmList.Count;
            int numExistAlarms = lvAlarm.Items.Count;

            if (numDBAlarms > numExistAlarms) 
            {
                foreach (AlarmEntity alarm in alarmList)
                {
                    string[] listViewItem = new string[]
                    {
                        alarm.PartitionKey,
                        alarm.RowKey,
                        alarm.Acknowledge.ToString(),
                    };
                    ListViewItem item = new ListViewItem(listViewItem);
                    Color alarmColor = Color.FromArgb(Convert.ToInt32(alarm.AlarmColor));
                    item.BackColor = alarmColor;
                    list.Add(item);
                }

                for (int i = numExistAlarms; i < numDBAlarms; i++)
                {
                    lvAlarm.Items.Add(list[i]);
                }
            }
        }

        private void LvAlarm_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;

            Color rowColor = e.Item.Selected ? Color.Blue : e.Item.BackColor; // Set color to blue if selected

            using (Brush backBrush = new SolidBrush(rowColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, e.Bounds, e.Item.ForeColor, flags);
        }

        private void LvAlarm_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = false;

            // Determine the text and background colors based on selection and column index
            Color backColor, textColor;
            if (e.Item.Selected)
            {
                backColor = Color.Blue; // Color when item is selected
                textColor = Color.White; // Text color when item is selected
            }
            else if (e.ColumnIndex == 1) // Handling the timestamp column separately
            {
                backColor = e.Item.BackColor; // Maintaining the original background color
                textColor = Color.Black; // Setting a fixed text color for timestamp
            }
            else
            {
                backColor = e.Item.BackColor;
                textColor = e.Item.ForeColor;
            }

            // Fill the background
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Draw the text
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds, textColor, flags);
        }


        private void LvAlarm_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true; // Use the default style to draw column headers
        }

        private async void btnAcknowledgeAlarm_Click(object sender, EventArgs e)
        {
            if (lvAlarm.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAlarm.SelectedItems[0];
                if (selectedItem.SubItems.Count < 3)
                {
                    selectedItem.SubItems.Add("True");
                    selectedItem.BackColor = Color.Yellow;
                    foreach (ListViewItem item in lvAlarm.SelectedItems)
                    {
                        AlarmEntity alarm = new AlarmEntity();
                        alarm.PartitionKey = item.SubItems[0].Text;
                        alarm.RowKey = item.SubItems[1].Text;
                        alarm.Acknowledge = bool.Parse(item.SubItems[2].Text);
                        alarm.AlarmColor = item.BackColor.ToArgb().ToString();
                        await logClient.UpdateAlarm(alarm);
                    }
                }
                else
                {
                    selectedItem.SubItems[2].Text = "True";
                    selectedItem.BackColor = Color.Yellow;
                    foreach (ListViewItem item in lvAlarm.SelectedItems)
                    {
                        AlarmEntity alarm = new AlarmEntity();
                        alarm.PartitionKey = item.SubItems[0].Text;
                        alarm.RowKey = item.SubItems[1].Text;
                        alarm.Acknowledge = bool.Parse(item.SubItems[2].Text);
                        alarm.AlarmColor = item.BackColor.ToArgb().ToString();
                        await logClient.UpdateAlarm(alarm);
                    }
                }
            }
        }

        private async void btnDeleteAlarm_Click(object sender, EventArgs e)
        {
            if (lvAlarm.SelectedItems.Count > 0) // Check if at least one item is selected
            {
                foreach (ListViewItem item in lvAlarm.SelectedItems) //Deletes all selected items
                {
                    AlarmEntity alarm = new AlarmEntity();
                    alarm.PartitionKey = item.SubItems[0].Text;
                    alarm.RowKey = item.SubItems[1].Text;
                    await logClient.DeleteAlarm(alarm);
                    lvAlarm.Items.Remove(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alarmEntity = new AlarmEntity("Dette er en Alarm", false, DateTime.Now, false, Color.Red);

            logClient.AddAlarmEntity(alarmEntity);
        }
    }
}
