namespace ProjectIndustrialControlSystems.UserControls
{
    partial class ucHome
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
            this.txtPoolLog = new System.Windows.Forms.RichTextBox();
            this.tbPoolTemp = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSetPoolTemp = new System.Windows.Forms.TrackBar();
            this.txtPoolTemp = new System.Windows.Forms.TextBox();
            this.txtSetPoolTemp = new System.Windows.Forms.TextBox();
            this.btnEmptyLog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtAutoManual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbPoolTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSetPoolTemp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPoolLog
            // 
            this.txtPoolLog.Location = new System.Drawing.Point(0, 1);
            this.txtPoolLog.Name = "txtPoolLog";
            this.txtPoolLog.ReadOnly = true;
            this.txtPoolLog.Size = new System.Drawing.Size(1698, 240);
            this.txtPoolLog.TabIndex = 0;
            this.txtPoolLog.Text = "";
            // 
            // tbPoolTemp
            // 
            this.tbPoolTemp.BackColor = System.Drawing.SystemColors.Control;
            this.tbPoolTemp.Location = new System.Drawing.Point(160, 27);
            this.tbPoolTemp.Maximum = 50;
            this.tbPoolTemp.Name = "tbPoolTemp";
            this.tbPoolTemp.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbPoolTemp.Size = new System.Drawing.Size(69, 353);
            this.tbPoolTemp.TabIndex = 1;
            this.tbPoolTemp.Tag = "Temperature";
            this.tbPoolTemp.TickFrequency = 5;
            this.tbPoolTemp.Value = 25;
            this.tbPoolTemp.Scroll += new System.EventHandler(this.tbPoolTemp_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pool temperature:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Set temperature:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "0°C";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "25°C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "50°C";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(492, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "50°C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(492, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "25°C";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(492, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "0°C";
            // 
            // tbSetPoolTemp
            // 
            this.tbSetPoolTemp.BackColor = System.Drawing.SystemColors.Control;
            this.tbSetPoolTemp.Location = new System.Drawing.Point(452, 27);
            this.tbSetPoolTemp.Maximum = 50;
            this.tbSetPoolTemp.Name = "tbSetPoolTemp";
            this.tbSetPoolTemp.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbSetPoolTemp.Size = new System.Drawing.Size(69, 353);
            this.tbSetPoolTemp.TabIndex = 9;
            this.tbSetPoolTemp.Tag = "Temperature";
            this.tbSetPoolTemp.TickFrequency = 5;
            this.tbSetPoolTemp.Value = 25;
            this.tbSetPoolTemp.Scroll += new System.EventHandler(this.tbSetPoolTemp_Scroll);
            // 
            // txtPoolTemp
            // 
            this.txtPoolTemp.Location = new System.Drawing.Point(150, 386);
            this.txtPoolTemp.Name = "txtPoolTemp";
            this.txtPoolTemp.ReadOnly = true;
            this.txtPoolTemp.Size = new System.Drawing.Size(79, 26);
            this.txtPoolTemp.TabIndex = 13;
            // 
            // txtSetPoolTemp
            // 
            this.txtSetPoolTemp.Location = new System.Drawing.Point(442, 386);
            this.txtSetPoolTemp.Name = "txtSetPoolTemp";
            this.txtSetPoolTemp.Size = new System.Drawing.Size(79, 26);
            this.txtSetPoolTemp.TabIndex = 14;
            this.txtSetPoolTemp.TextChanged += new System.EventHandler(this.txtSetPoolTemp_TextChanged);
            // 
            // btnEmptyLog
            // 
            this.btnEmptyLog.AutoSize = true;
            this.btnEmptyLog.Location = new System.Drawing.Point(3, 247);
            this.btnEmptyLog.Name = "btnEmptyLog";
            this.btnEmptyLog.Size = new System.Drawing.Size(1684, 61);
            this.btnEmptyLog.TabIndex = 17;
            this.btnEmptyLog.Text = "Empty log";
            this.btnEmptyLog.UseVisualStyleBackColor = true;
            this.btnEmptyLog.Click += new System.EventHandler(this.btnEmptyLog_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.txtSetPoolTemp);
            this.groupBox1.Controls.Add(this.txtPoolTemp);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbSetPoolTemp);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPoolTemp);
            this.groupBox1.Location = new System.Drawing.Point(32, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 529);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature controls";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(150, 436);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(87, 24);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "Manuel";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // txtAutoManual
            // 
            this.txtAutoManual.Location = new System.Drawing.Point(871, 339);
            this.txtAutoManual.Name = "txtAutoManual";
            this.txtAutoManual.ReadOnly = true;
            this.txtAutoManual.Size = new System.Drawing.Size(92, 26);
            this.txtAutoManual.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(722, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Basseng er satt i:";
            // 
            // ucHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAutoManual);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEmptyLog);
            this.Controls.Add(this.txtPoolLog);
            this.Name = "ucHome";
            this.Size = new System.Drawing.Size(1699, 1332);
            ((System.ComponentModel.ISupportInitialize)(this.tbPoolTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSetPoolTemp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtPoolLog;
        private System.Windows.Forms.TrackBar tbPoolTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar tbSetPoolTemp;
        private System.Windows.Forms.TextBox txtPoolTemp;
        private System.Windows.Forms.TextBox txtSetPoolTemp;
        private System.Windows.Forms.Button btnEmptyLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox txtAutoManual;
        private System.Windows.Forms.Label label6;
    }
}
