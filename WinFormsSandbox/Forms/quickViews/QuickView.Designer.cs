namespace WinFormsSandbox.Forms
{
    partial class QuickView
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
            this.labelCaption = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip = new WinFormsSandbox.Forms.IllumToolStrip();
            this.resizeStrip = new WinFormsSandbox.Forms.ResizeStrip();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCaption
            // 
            this.labelCaption.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(49, 22);
            this.labelCaption.Text = "Caption";
            this.labelCaption.DoubleClick += new System.EventHandler(this.toolStrip_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelCaption});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(276, 25);
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Click += new System.EventHandler(this.toolStrip_Click);
            // 
            // resizeStrip
            // 
            this.resizeStrip.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.resizeStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.resizeStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resizeStrip.Location = new System.Drawing.Point(0, 233);
            this.resizeStrip.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.resizeStrip.Name = "resizeStrip";
            this.resizeStrip.Size = new System.Drawing.Size(276, 5);
            this.resizeStrip.TabIndex = 13;
            this.resizeStrip.Text = "resizeStrip1";
            // 
            // QuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resizeStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "QuickView";
            this.Size = new System.Drawing.Size(276, 238);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IllumToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel labelCaption;
        private ResizeStrip resizeStrip;
    }
}
