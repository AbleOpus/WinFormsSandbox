namespace WinFormsSandbox.Forms
{
    partial class LoadAssemQuickView
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
            this.buttonAddProbingPath = new System.Windows.Forms.Button();
            this.buttonFromGAC = new System.Windows.Forms.Button();
            this.buttonLoadAssemblies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddProbingPath
            // 
            this.buttonAddProbingPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAddProbingPath.Image = global::WinFormsSandbox.Properties.Resources.Add;
            this.buttonAddProbingPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddProbingPath.Location = new System.Drawing.Point(0, 95);
            this.buttonAddProbingPath.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddProbingPath.Name = "buttonAddProbingPath";
            this.buttonAddProbingPath.Size = new System.Drawing.Size(271, 35);
            this.buttonAddProbingPath.TabIndex = 2;
            this.buttonAddProbingPath.Text = "Add probing path...";
            this.buttonAddProbingPath.UseVisualStyleBackColor = true;
            this.buttonAddProbingPath.Click += new System.EventHandler(this.buttonAddProbingPath_Click);
            // 
            // buttonFromGAC
            // 
            this.buttonFromGAC.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFromGAC.Image = global::WinFormsSandbox.Properties.Resources.AssemblyImage;
            this.buttonFromGAC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFromGAC.Location = new System.Drawing.Point(0, 60);
            this.buttonFromGAC.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFromGAC.Name = "buttonFromGAC";
            this.buttonFromGAC.Size = new System.Drawing.Size(271, 35);
            this.buttonFromGAC.TabIndex = 1;
            this.buttonFromGAC.Text = "Load From GAC...";
            this.buttonFromGAC.UseVisualStyleBackColor = true;
            this.buttonFromGAC.Click += new System.EventHandler(this.buttonFromGAC_Click);
            // 
            // buttonLoadAssemblies
            // 
            this.buttonLoadAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLoadAssemblies.Image = global::WinFormsSandbox.Properties.Resources.AssemblyImage;
            this.buttonLoadAssemblies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadAssemblies.Location = new System.Drawing.Point(0, 25);
            this.buttonLoadAssemblies.Name = "buttonLoadAssemblies";
            this.buttonLoadAssemblies.Size = new System.Drawing.Size(271, 35);
            this.buttonLoadAssemblies.TabIndex = 0;
            this.buttonLoadAssemblies.Text = "Load 3rd-party assemblies...";
            this.buttonLoadAssemblies.UseVisualStyleBackColor = true;
            // 
            // LoadAssemQuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Load Assemblies:";
            this.Controls.Add(this.buttonAddProbingPath);
            this.Controls.Add(this.buttonFromGAC);
            this.Controls.Add(this.buttonLoadAssemblies);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "LoadAssemQuickView";
            this.Size = new System.Drawing.Size(271, 256);
            this.Controls.SetChildIndex(this.buttonLoadAssemblies, 0);
            this.Controls.SetChildIndex(this.buttonFromGAC, 0);
            this.Controls.SetChildIndex(this.buttonAddProbingPath, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddProbingPath;
        private System.Windows.Forms.Button buttonLoadAssemblies;
        private System.Windows.Forms.Button buttonFromGAC;
    }
}
