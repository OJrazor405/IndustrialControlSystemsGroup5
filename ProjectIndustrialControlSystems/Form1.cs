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

namespace ProjectIndustrialControlSystems
{
    public partial class Form1 : Form
    {
        //Makes an instance of the objects to display in Form1
        NavigationControl navigationControl;
        ucHome homePage = new ucHome();
        ucAlarms alarmPage = new ucAlarms();
        ucSettings settingsPage = new ucSettings();

        public Form1()
        {
            InitializeComponent();
            InitializeNavigationControl();
        }

        private void InitializeNavigationControl()
        {

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
