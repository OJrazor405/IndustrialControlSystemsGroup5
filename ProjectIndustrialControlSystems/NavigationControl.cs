using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectIndustrialControlSystems
{
    public class NavigationControl
    {
        List<UserControl> userControlList = new List<UserControl>();
        Panel panel;

        public NavigationControl(List<UserControl> userControlList, Panel panel)
        {
            this.userControlList = userControlList;
            this.panel = panel;
            AddUserControl();
        }

        private void AddUserControl()
        {
            for (int i = 0; i < userControlList.Count(); i++)
            {
                // Set every UserControl's dock style to fill so that it will occupy the space inside the panel
                userControlList[i].Dock = DockStyle.Fill;
                // Add all the UserControl inside the panel
                panel.Controls.Add(userControlList[i]);
            }
        }

        public void Display(int index)
        {
            if (index < userControlList.Count())
            {
                // Display only the selected UserControl using index
                userControlList[index].BringToFront();
            }
        }
    }
}
