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
        AlarmEntity alarmEntityLow;
        AlarmEntity alarmEntityHigh;
        ucAlarms alarmPage;
        bool tempMan = false;
        bool alarmSetHigh = false;
        bool alarmSetLow = false;
        string poolStatus = "";

        public ucHome(ucAlarms alarmPage)
        {
            InitializeComponent();
            StartDataLoading();
            logClient = new LogClient();
            txtSetPoolTemp.Text = tbSetPoolTemp.Value.ToString();
            txtPoolTemp.Text = tbPoolTemp.Value.ToString();
            this.alarmPage = alarmPage;
        }
        private async Task StartDataLoading()
        {
            IoTClient ioTClient = new IoTClient();
            while (true)
            {
                sensorData = await ioTClient.IoTMethodParse("SendSensorData");
                await updateTbPoolTemp();
                await LogPoolData();
                Thread.Sleep(100);
            }
        }

        private async Task updateTbPoolTemp()
        {
            if (!tempMan)//auto, får verdier fra Rpi
            {
                tbPoolTemp.Value = int.Parse(sensorData.Temperature.ToString("0"));
                txtPoolTemp.Text = tbPoolTemp.Value.ToString();
                if (tbPoolTemp.Value <= tbSetPoolTemp.Value - 5)
                {
                    if (!alarmSetLow)
                    {
                        alarmEntityLow = new AlarmEntity("Temperatur basseng lav", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntityLow);
                        alarmSetLow = true;
                        await alarmPage.UpdateAlarmsAsync();
                    }
                }
                else if (tbPoolTemp.Value > tbSetPoolTemp.Value - 5 && alarmSetLow == true)
                {
                    alarmSetLow = false;
                    alarmEntityLow.State = false;
                    alarmEntityLow.AlarmColor = Color.Yellow.ToArgb().ToString();
                    await logClient.UpdateAlarm(alarmEntityLow);
                    await alarmPage.UpdateAlarmsAsync();

                }
                else if (tbPoolTemp.Value >= tbSetPoolTemp.Value + 5)
                {
                    if (!alarmSetHigh)
                    {
                        alarmEntityHigh = new AlarmEntity("Temperatur basseng høy", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntityHigh);
                        alarmSetHigh = true;
                        await alarmPage.UpdateAlarmsAsync();

                    }
                }
                else if (tbPoolTemp.Value < tbSetPoolTemp.Value + 5 && alarmSetHigh == true)
                {
                    alarmSetHigh = false;
                    alarmEntityHigh.State = false;
                    alarmEntityHigh.AlarmColor = Color.Yellow.ToArgb().ToString();
                    await logClient.UpdateAlarm(alarmEntityHigh);
                    await alarmPage.UpdateAlarmsAsync();

                }
            }
        }

        private async Task LogPoolData()
        {
            string poolStatusFromPi = sensorData.BassengI;
            if (poolStatusFromPi != poolStatus)
            {
                poolStatus = poolStatusFromPi;
                txtPoolLog.AppendText("Bassenget er satt i " + poolStatus + " " + DateTime.Now.ToString() + "\r\n");
                txtAutoManual.Text = poolStatus;
                if (poolStatus == "auto")
                {
                    txtAutoManual.BackColor = Color.Red;
                }
                else
                {
                    txtAutoManual.BackColor = Color.Green;
                }
            }
        }

        private async void tbPoolTemp_Scroll(object sender, EventArgs e)
        {
            if (tempMan)
            {
                txtPoolTemp.Text = tbPoolTemp.Value.ToString("0");
                if (tbPoolTemp.Value <= tbSetPoolTemp.Value - 5)
                {
                    if (!alarmSetLow)
                    {
                        alarmEntityLow = new AlarmEntity("Temperatur basseng lav", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntityLow);
                        alarmSetLow = true;
                        await alarmPage.UpdateAlarmsAsync();

                    }
                }
                else if (tbPoolTemp.Value > tbSetPoolTemp.Value - 5 && alarmSetLow == true)
                {
                    alarmSetLow = false;
                    alarmEntityLow.State = false;
                    alarmEntityLow.AlarmColor = Color.Yellow.ToArgb().ToString();
                    await logClient.UpdateAlarm(alarmEntityLow);
                    await alarmPage.UpdateAlarmsAsync();

                }
                else if (tbPoolTemp.Value >= tbSetPoolTemp.Value + 5)
                {
                    if (!alarmSetHigh)
                    {
                        alarmEntityHigh = new AlarmEntity("Temperatur basseng høy", false, DateTime.Now, true, Color.Red);
                        logClient.AddAlarmEntity(alarmEntityHigh);
                        alarmSetHigh = true;
                        await alarmPage.UpdateAlarmsAsync();

                    }
                }
                else if (tbPoolTemp.Value < tbSetPoolTemp.Value + 5 && alarmSetHigh == true)
                {
                    alarmSetHigh = false;
                    alarmEntityHigh.State = false;
                    alarmEntityHigh.AlarmColor = Color.Yellow.ToArgb().ToString();
                    await logClient.UpdateAlarm(alarmEntityHigh);
                    await alarmPage.UpdateAlarmsAsync();

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
