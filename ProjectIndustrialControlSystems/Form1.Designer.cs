namespace ProjectIndustrialControlSystems
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmHome = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAlarms = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHome,
            this.tsmAlarms,
            this.tsmSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(182, 1290);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmHome
            // 
            this.tsmHome.AutoSize = false;
            this.tsmHome.Image = ((System.Drawing.Image)(resources.GetObject("tsmHome.Image")));
            this.tsmHome.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmHome.Name = "tsmHome";
            this.tsmHome.Size = new System.Drawing.Size(173, 50);
            this.tsmHome.Text = "Home";
            this.tsmHome.Click += new System.EventHandler(this.tsmHome_Click);
            // 
            // tsmAlarms
            // 
            this.tsmAlarms.AutoSize = false;
            this.tsmAlarms.Image = ((System.Drawing.Image)(resources.GetObject("tsmAlarms.Image")));
            this.tsmAlarms.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmAlarms.Name = "tsmAlarms";
            this.tsmAlarms.Size = new System.Drawing.Size(173, 50);
            this.tsmAlarms.Text = "Alarms";
            this.tsmAlarms.Click += new System.EventHandler(this.tsmAlarms_Click);
            // 
            // tsmSettings
            // 
            this.tsmSettings.AutoSize = false;
            this.tsmSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsmSettings.Image")));
            this.tsmSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmSettings.Name = "tsmSettings";
            this.tsmSettings.Size = new System.Drawing.Size(170, 50);
            this.tsmSettings.Text = "Settings";
            this.tsmSettings.Click += new System.EventHandler(this.tsmSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(182, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1468, 1290);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1650, 1290);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmHome;
        private System.Windows.Forms.ToolStripMenuItem tsmAlarms;
        private System.Windows.Forms.ToolStripMenuItem tsmSettings;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
    }
}

