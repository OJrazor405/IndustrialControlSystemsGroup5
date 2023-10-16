using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectIndustrialControlSystems.UserControls
{
    public partial class ucAlarms : UserControl
    {
        List<Color> alarmColors;
        public ucAlarms()
        {
            InitializeComponent();
            alarmColors = new List<Color>()
            {
                Color.Blue, Color.Green, Color.Red, Color.Yellow
            };
            foreach (Color color in alarmColors)
            {
                cboAlarmColor.Items.Add(color);
            };
        }

        private void btnAddAlarm_Click(object sender, EventArgs e)
        {
            string alarmText = txtAlarmText.Text;
            txtAlarmWindow.AppendText(alarmText + "\r\n");
        }
    }
}
