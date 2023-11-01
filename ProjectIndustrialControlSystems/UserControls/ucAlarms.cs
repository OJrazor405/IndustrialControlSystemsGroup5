using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        LogClient logClient;
        AlarmEntity alarmEntity;

        public ucAlarms()
        {
            InitializeComponent();
            InitializeListView();
            logClient = new LogClient();
            IEnumerable<AlarmEntity> alarms = await logClient.GetAllAlarmsAsync();
            List<AlarmEntity> alarmList = alarms.ToList();

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

        public void AddItem(string text, Color backColor, string timestamp)
        {
            string[] listViewItems = new string[]
            {
                text,
                timestamp
            };
            ListViewItem item = new ListViewItem(listViewItems);
            item.BackColor = backColor;
            lvAlarm.Items.Add(item);
        }

        private void btnAcknowledgeAlarm_Click(object sender, EventArgs e)
        {
            if (lvAlarm.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAlarm.SelectedItems[0];
                if (selectedItem.SubItems.Count < 3)
                {
                    selectedItem.SubItems.Add("Acknowledged");
                    selectedItem.BackColor = Color.Yellow;
                }
                else
                {
                    selectedItem.SubItems[2].Text = "Acknowledged";
                    selectedItem.BackColor = Color.Yellow;
                }
            }
        }

        private void btnDeleteAlarm_Click(object sender, EventArgs e)
        {
            if (lvAlarm.SelectedItems.Count > 0) // Check if at least one item is selected
            {
                foreach (ListViewItem item in lvAlarm.SelectedItems) //Deletes all selected items
                {
                    lvAlarm.Items.Remove(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alarmEntity = new AlarmEntity("This is an alarm", false, DateTime.Now.ToString(), false, Color.Red);
            AddItem(alarmEntity.PartitionKey, alarmEntity.AlarmColor, alarmEntity.RowKey);
            logClient.AddAlarmEntity("alarms", alarmEntity);
            //AddItem("This is an alarm", Color.Red, DateTime.Now.ToString());
            //AddItem("This is an alarm", Color.Red, DateTime.Now.ToString());
            //AddItem("This is an alarm", Color.White, DateTime.Now.ToString());
            //AddItem("This is an alarm", Color.Red, DateTime.Now.ToString());
            //AddItem("This is an alarm", Color.Yellow, DateTime.Now.ToString());
            //AddItem("This is an alarm", Color.Red, DateTime.Now.ToString());
            //AddItem("This is an alarm", Color.Yellow, DateTime.Now.ToString());
            //AddItem("This is an alarm", Color.Red, DateTime.Now.ToString());
        }
    }
}
