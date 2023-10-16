namespace ProjectIndustrialControlSystems.UserControls
{
    partial class ucAlarms
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAlarms));
            this.txtAlarmWindow = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.btnAddAlarm = new System.Windows.Forms.Button();
            this.txtAlarmText = new System.Windows.Forms.TextBox();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.lblAlarmColor = new System.Windows.Forms.Label();
            this.cboAlarmColor = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAlarmWindow
            // 
            this.txtAlarmWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAlarmWindow.Location = new System.Drawing.Point(0, 0);
            this.txtAlarmWindow.Name = "txtAlarmWindow";
            this.txtAlarmWindow.ReadOnly = true;
            this.txtAlarmWindow.Size = new System.Drawing.Size(3177, 707);
            this.txtAlarmWindow.TabIndex = 0;
            this.txtAlarmWindow.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAlarmColor);
            this.groupBox1.Controls.Add(this.lblAlarmColor);
            this.groupBox1.Controls.Add(this.lblAlarm);
            this.groupBox1.Controls.Add(this.txtAlarmText);
            this.groupBox1.Controls.Add(this.btnAddAlarm);
            this.groupBox1.Controls.Add(this.btnAcknowledge);
            this.groupBox1.Location = new System.Drawing.Point(3, 713);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 206);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAcknowledge.Image = ((System.Drawing.Image)(resources.GetObject("btnAcknowledge.Image")));
            this.btnAcknowledge.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAcknowledge.Location = new System.Drawing.Point(570, 42);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(156, 45);
            this.btnAcknowledge.TabIndex = 1;
            this.btnAcknowledge.Text = "Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = true;
            // 
            // btnAddAlarm
            // 
            this.btnAddAlarm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddAlarm.Location = new System.Drawing.Point(376, 42);
            this.btnAddAlarm.Name = "btnAddAlarm";
            this.btnAddAlarm.Size = new System.Drawing.Size(156, 45);
            this.btnAddAlarm.TabIndex = 2;
            this.btnAddAlarm.Text = "Add";
            this.btnAddAlarm.UseVisualStyleBackColor = true;
            this.btnAddAlarm.Click += new System.EventHandler(this.btnAddAlarm_Click);
            // 
            // txtAlarmText
            // 
            this.txtAlarmText.Location = new System.Drawing.Point(29, 51);
            this.txtAlarmText.Name = "txtAlarmText";
            this.txtAlarmText.Size = new System.Drawing.Size(308, 26);
            this.txtAlarmText.TabIndex = 3;
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Location = new System.Drawing.Point(25, 22);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(84, 20);
            this.lblAlarm.TabIndex = 4;
            this.lblAlarm.Text = "Alarm text:";
            // 
            // lblAlarmColor
            // 
            this.lblAlarmColor.AutoSize = true;
            this.lblAlarmColor.Location = new System.Drawing.Point(25, 88);
            this.lblAlarmColor.Name = "lblAlarmColor";
            this.lblAlarmColor.Size = new System.Drawing.Size(92, 20);
            this.lblAlarmColor.TabIndex = 5;
            this.lblAlarmColor.Text = "Alarm color:";
            // 
            // cboAlarmColor
            // 
            this.cboAlarmColor.FormattingEnabled = true;
            this.cboAlarmColor.Location = new System.Drawing.Point(29, 111);
            this.cboAlarmColor.Name = "cboAlarmColor";
            this.cboAlarmColor.Size = new System.Drawing.Size(308, 28);
            this.cboAlarmColor.TabIndex = 6;
            // 
            // ucAlarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAlarmWindow);
            this.Name = "ucAlarms";
            this.Size = new System.Drawing.Size(3177, 2043);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtAlarmWindow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboAlarmColor;
        private System.Windows.Forms.Label lblAlarmColor;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.TextBox txtAlarmText;
        private System.Windows.Forms.Button btnAddAlarm;
        private System.Windows.Forms.Button btnAcknowledge;
    }
}
