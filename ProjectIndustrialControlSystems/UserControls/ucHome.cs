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
        SensorData sensorData;
        AlarmEntity alarmEntity;
        bool tempMan = false;
        bool alarmSet = false;

        public ucHome()
        {
            InitializeComponent();
            StartDataLoading();
            logClient = new LogClient();
            txtSetPoolTemp.Text = tbSetPoolTemp.Value.ToString();
            txtPoolTemp.Text = tbPoolTemp.Value.ToString();
        }
        private async Task StartDataLoading()
        {
            IoTClient ioTClient = new IoTClient();
            while (true)
            {
                sensorData = await ioTClient.IoTMethodParse("SendSensorData");
                updateTbPoolTemp();
                Thread.Sleep(1000);
            }
        }

        private void updateTbPoolTemp()
        {
            if (!tempMan)//auto, får verdier fra Rpi
            {
                tbPoolTemp.Value = int.Parse(sensorData.Temperature.ToString("0"));
                txtPoolTemp.Text = tbPoolTemp.Value.ToString();
                if (tbPoolTemp.Value <= tbSetPoolTemp.Value - 5)
                {
                    if (!alarmSet)
                    {
                        alarmEntity = new AlarmEntity("Temperatur basseng lav", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntity);
                        alarmSet = true;
                    }
                }
                else if (tbPoolTemp.Value > tbSetPoolTemp.Value - 5)
                {
                    alarmSet = false;
                }
                else if (tbPoolTemp.Value >= tbSetPoolTemp.Value + 5)
                {
                    if (!alarmSet)
                    {
                        alarmEntity = new AlarmEntity("Temperatur basseng høy", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntity);
                        alarmSet = true;
                    }
                }
                else if (tbPoolTemp.Value < tbSetPoolTemp.Value + 5)
                {
                       alarmSet = false;
                }
            }
        }

        private void tbPoolTemp_Scroll(object sender, EventArgs e)
        {
            if (tempMan)
            {
                txtPoolTemp.Text = tbPoolTemp.Value.ToString("0");
                if (tbPoolTemp.Value <= tbSetPoolTemp.Value - 5)
                {
                    if (!alarmSet)
                    {
                        alarmEntity = new AlarmEntity("Temperatur basseng lav", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntity);
                        alarmSet = true;
                    }
                }
                else if (tbPoolTemp.Value > tbSetPoolTemp.Value - 5)
                {
                    alarmSet = false;
                }
                else if (tbPoolTemp.Value >= tbSetPoolTemp.Value + 5)
                {
                    if (!alarmSet)
                    {
                        alarmEntity = new AlarmEntity("Temperatur basseng høy", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntity);
                        alarmSet = true;
                    }
                }
                else if (tbPoolTemp.Value < tbSetPoolTemp.Value + 5)
                {
                    alarmSet = false;
                }
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tempMan = !tempMan;
        }
    }
}
