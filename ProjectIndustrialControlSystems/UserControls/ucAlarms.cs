using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private LogClient _logClient = new LogClient();
        private List<AlarmEntity> _alarmList;
        private System.Timers.Timer _alarmUpdateTimer;

        public ucAlarms()
        {
            InitializeComponent();
            InitializeListView();
            //SetupAlarmUpdateTimer();
        }

        private async void InitializeListView()
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
            lvAlarm.Columns.Add("State", 120, HorizontalAlignment.Left);

            //Draws items to the listview
            lvAlarm.DrawItem += LvAlarm_DrawItem;
            lvAlarm.DrawSubItem += LvAlarm_DrawSubItem;
            lvAlarm.DrawColumnHeader += LvAlarm_DrawColumnHeader;
            await UpdateAlarmsAsync();
        }

        //private void SetupAlarmUpdateTimer()
        //{
        //    _alarmUpdateTimer = new System.Timers.Timer(1000); // Set up the timer for 1 second
        //    _alarmUpdateTimer.Elapsed += async (sender, e) => await UpdateAlarmsAsync();
        //    _alarmUpdateTimer.AutoReset = true;
        //    _alarmUpdateTimer.Enabled = true;
        //}

        public async Task UpdateAlarmsAsync()
        {
            // Calling GetAllAlarmsAsync and storing the values in a list
            IEnumerable<AlarmEntity> alarms = await _logClient.GetAllAlarmsAsync();
            _alarmList = alarms.ToList();
            List<ListViewItem> list = new List<ListViewItem>();
            int numDBAlarms = _alarmList.Count;
            int numExistAlarms = lvAlarm.Items.Count;
            lvAlarm.Items.Clear();

            foreach (AlarmEntity alarm in _alarmList.OrderByDescending(a => a.Timestamp))
            {
                string[] listViewItem = new string[]
                {
                    alarm.PartitionKey,
                    alarm.RowKey,
                    alarm.Acknowledged.ToString(),
                    alarm.State.ToString(),
                };
                ListViewItem item = new ListViewItem(listViewItem);
                Color alarmColor = Color.FromArgb(Convert.ToInt32(alarm.AlarmColor));
                item.BackColor = alarmColor;
                lvAlarm.Items.Add(item);
            }

            //if (lvAlarm.InvokeRequired)
            //{
            //    lvAlarm.Invoke(new MethodInvoker(delegate
            //    {
            //        UpdateListViewItems(list, numExistAlarms, numDBAlarms);
            //    }));
            //}
            //else
            //{
            //    UpdateListViewItems(list, numExistAlarms, numDBAlarms);
            //}
            
        }

        private void UpdateListViewItems(List<ListViewItem> list, int numExistAlarms, int numDBAlarms)
        {
            for (int i = numExistAlarms; i < numDBAlarms; i++)
            {
                lvAlarm.Items.Add(list[i]);
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

        private async Task<string> crudAlarms(string operation)
        {
            foreach (ListViewItem item in lvAlarm.SelectedItems)
            {;
                AlarmEntity alarm = new AlarmEntity
                (
                    item.SubItems[0].Text,
                    bool.Parse(item.SubItems[2].Text),
                    DateTime.Parse(item.SubItems[1].Text),
                    bool.Parse(item.SubItems[3].Text),
                    item.BackColor
                );
                if (operation == "Update")
                {
                    await _logClient.UpdateAlarm(alarm);
                }
                else if (operation == "Delete")
                {
                    await _logClient.DeleteAlarm(alarm);
                }
            }

            return operation;
        }

        private async void AcknowledgeSelectedAlarms()
        {
            if (lvAlarm.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvAlarm.SelectedItems[0];
                if (selectedItem.SubItems.Count < 3)
                {
                    selectedItem.SubItems.Add("True");
                    if (selectedItem.SubItems[3].Text == "False")
                    {
                        selectedItem.BackColor = Color.White;
                    }
                    else
                    {
                        selectedItem.BackColor = Color.Yellow;
                    }
                    foreach (ListViewItem item in lvAlarm.SelectedItems)
                    {
                        await crudAlarms("Update");
                    }
                }
                else
                {
                    selectedItem.SubItems[2].Text = "True";
                    if (selectedItem.SubItems[3].Text == "False")
                    {
                        selectedItem.BackColor = Color.White;
                    }
                    else
                    {
                        selectedItem.BackColor = Color.Yellow;
                    }
                    await crudAlarms("Update");
                }
            }
        }

        private async void DeleteSelectedAlarms()
        {
            if (lvAlarm.SelectedItems.Count > 0) // Check if at least one item is selected
            {
                foreach (ListViewItem item in lvAlarm.SelectedItems) //Deletes all selected items
                {
                    await crudAlarms("Delete");
                    lvAlarm.Items.Remove(item);
                }
            }
        }

        private void AddTestAlarm()
        {
            AlarmEntity alarmEntity = new AlarmEntity("Dette er en Alarm", false, DateTime.Now, true, Color.Red);

            _logClient.AddAlarmEntity(alarmEntity);
        }

        // Event handlers for button clicks that call the appropriate methods
        private void btnAcknowledgeAlarm_Click(object sender, EventArgs e)
        {
            AcknowledgeSelectedAlarms();
        }

        private void btnDeleteAlarm_Click(object sender, EventArgs e)
        {
            DeleteSelectedAlarms();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            AddTestAlarm();
            await UpdateAlarmsAsync();
        }
    }
}
