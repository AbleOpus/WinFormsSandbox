namespace WinFormsSandbox.Forms
{
    partial class PropertiesQuickView
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
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.contextPropGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.contextPropGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.ContextMenuStrip = this.contextPropGrid;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 25);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(322, 245);
            this.propertyGrid.TabIndex = 0;
            // 
            // contextPropGrid
            // 
            this.contextPropGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReset});
            this.contextPropGrid.Name = "contextPropGrid";
            this.contextPropGrid.Size = new System.Drawing.Size(103, 26);
            this.contextPropGrid.Opening += new System.ComponentModel.CancelEventHandler(this.contextPropGrid_Opening);
            // 
            // menuItemReset
            // 
            this.menuItemReset.Name = "menuItemReset";
            this.menuItemReset.Size = new System.Drawing.Size(102, 22);
            this.menuItemReset.Text = "Reset";
            this.menuItemReset.Click += new System.EventHandler(this.menuItemReset_Click);
            // 
            // PropertiesQuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Properties";
            this.Controls.Add(this.propertyGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "PropertiesQuickView";
            this.Size = new System.Drawing.Size(322, 275);
            this.Controls.SetChildIndex(this.propertyGrid, 0);
            this.contextPropGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ContextMenuStrip contextPropGrid;
        private System.Windows.Forms.ToolStripMenuItem menuItemReset;
    }
}
