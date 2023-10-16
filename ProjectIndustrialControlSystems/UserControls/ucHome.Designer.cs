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
            this.ucAlarms1 = new ProjectIndustrialControlSystems.UserControls.ucAlarms();
            this.SuspendLayout();
            // 
            // ucAlarms1
            // 
            this.ucAlarms1.CausesValidation = false;
            this.ucAlarms1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucAlarms1.Location = new System.Drawing.Point(0, 0);
            this.ucAlarms1.Name = "ucAlarms1";
            this.ucAlarms1.Size = new System.Drawing.Size(1699, 231);
            this.ucAlarms1.TabIndex = 0;
            // 
            // ucHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucAlarms1);
            this.Name = "ucHome";
            this.Size = new System.Drawing.Size(1699, 1332);
            this.ResumeLayout(false);

        }

        #endregion

        private ucAlarms ucAlarms1;
    }
}
