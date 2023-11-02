using ProjectIndustrialControlSystems.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProjectIndustrialControlSystems
{
    public partial class Form1 : Form
    {
        //Makes an instance of the objects to display in Form1
        NavigationControl navigationControl;

        ucAlarms alarmPage;
        ucHome homePage;
        ucSettings settingsPage;

        public Form1()
        {
            InitializeComponent();
            InitializeNavigationControl();
        }

        private void InitializeNavigationControl()
        {
            alarmPage = new ucAlarms(); // Initialize alarmPage here
            homePage = new ucHome(alarmPage); // Initialize homePage here
            settingsPage = new ucSettings();
            List<UserControl> userControls = new List<UserControl>()
            {
                homePage,
                alarmPage,
                settingsPage
            };

            navigationControl = new NavigationControl(userControls, panel1);
            navigationControl.Display(0);
            
        }

        private void tsmHome_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
        }

        private void tsmAlarms_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
        }

        private void tsmSettings_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
        }
    }
}
