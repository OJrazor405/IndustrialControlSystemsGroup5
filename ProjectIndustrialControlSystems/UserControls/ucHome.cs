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
    public partial class ucHome : UserControl
    {
        LogClient logClient;
        AlarmEntity alarm;

        public ucHome()
        {
            InitializeComponent();
            logClient = new LogClient();
            txtSetPoolTemp.Text = tbSetPoolTemp.Value.ToString();
            txtPoolTemp.Text = tbPoolTemp.Value.ToString();
        }

        private void tbPoolTemp_Scroll(object sender, EventArgs e)
        {
            txtPoolTemp.Text = tbPoolTemp.Value.ToString("0");
            if (tbPoolTemp.Value <= tbSetPoolTemp.Value - 5)
            {

            }
        }

        private void tbSetPoolTemp_Scroll(object sender, EventArgs e)
        {
            txtSetPoolTemp.Text = tbSetPoolTemp.Value.ToString("0");
        }

        private void txtSetPoolTemp_TextChanged(object sender, EventArgs e)
        {
            int setTemp;
            bool success = int.TryParse(txtSetPoolTemp.Text, out setTemp);
            if (success && setTemp <= 50 && setTemp >= 0)
            {
                tbSetPoolTemp.Value = setTemp;
            }
        }

        private void btnEmptyLog_Click(object sender, EventArgs e)
        {
            txtPoolLog.Text = string.Empty;
        }
    }
}
