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
            this.components = new System.ComponentModel.Container();
            this.btnAcknowledgeAlarm = new System.Windows.Forms.Button();
            this.btnDeleteAlarm = new System.Windows.Forms.Button();
            this.lvAlarm = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnAcknowledgeAlarm
            // 
            this.btnAcknowledgeAlarm.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAcknowledgeAlarm.Location = new System.Drawing.Point(3, 529);
            this.btnAcknowledgeAlarm.Name = "btnAcknowledgeAlarm";
            this.btnAcknowledgeAlarm.Size = new System.Drawing.Size(174, 58);
            this.btnAcknowledgeAlarm.TabIndex = 1;
            this.btnAcknowledgeAlarm.Text = "Acknowledge";
            this.btnAcknowledgeAlarm.UseVisualStyleBackColor = false;
            this.btnAcknowledgeAlarm.Click += new System.EventHandler(this.btnAcknowledgeAlarm_Click);
            // 
            // btnDeleteAlarm
            // 
            this.btnDeleteAlarm.BackColor = System.Drawing.Color.Yellow;
            this.btnDeleteAlarm.Location = new System.Drawing.Point(183, 529);
            this.btnDeleteAlarm.Name = "btnDeleteAlarm";
            this.btnDeleteAlarm.Size = new System.Drawing.Size(174, 58);
            this.btnDeleteAlarm.TabIndex = 2;
            this.btnDeleteAlarm.Text = "Delete";
            this.btnDeleteAlarm.UseVisualStyleBackColor = false;
            this.btnDeleteAlarm.Click += new System.EventHandler(this.btnDeleteAlarm_Click);
            // 
            // lvAlarm
            // 
            this.lvAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAlarm.HideSelection = false;
            this.lvAlarm.Location = new System.Drawing.Point(0, 0);
            this.lvAlarm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvAlarm.Name = "lvAlarm";
            this.lvAlarm.Size = new System.Drawing.Size(3177, 519);
            this.lvAlarm.TabIndex = 3;
            this.lvAlarm.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(734, 658);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 129);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Interval = 5000;
            // 
            // ucAlarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lvAlarm);
            this.Controls.Add(this.btnDeleteAlarm);
            this.Controls.Add(this.btnAcknowledgeAlarm);
            this.Name = "ucAlarms";
            this.Size = new System.Drawing.Size(3177, 2043);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAcknowledgeAlarm;
        private System.Windows.Forms.Button btnDeleteAlarm;
        private System.Windows.Forms.ListView lvAlarm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrAlarm;
    }
}
