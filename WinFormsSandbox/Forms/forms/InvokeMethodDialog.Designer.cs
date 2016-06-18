namespace WinFormsSandbox.Forms
{
    partial class InvokeMethodDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvokeMethodDialog));
            this.panelInput = new System.Windows.Forms.Panel();
            this.propertyGridMethodInfo = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.labelStringResult = new System.Windows.Forms.Label();
            this.propertyGridResult = new System.Windows.Forms.PropertyGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonInvoke = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelInput.SuspendLayout();
            this.panelOutput.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.propertyGridMethodInfo);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Location = new System.Drawing.Point(3, 3);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(284, 386);
            this.panelInput.TabIndex = 0;
            // 
            // propertyGridMethodInfo
            // 
            this.propertyGridMethodInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridMethodInfo.HelpVisible = false;
            this.propertyGridMethodInfo.Location = new System.Drawing.Point(0, 28);
            this.propertyGridMethodInfo.Name = "propertyGridMethodInfo";
            this.propertyGridMethodInfo.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.propertyGridMethodInfo.Size = new System.Drawing.Size(284, 358);
            this.propertyGridMethodInfo.TabIndex = 1;
            this.propertyGridMethodInfo.ToolbarVisible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Method Parameters";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelOutput
            // 
            this.panelOutput.Controls.Add(this.labelStringResult);
            this.panelOutput.Controls.Add(this.propertyGridResult);
            this.panelOutput.Controls.Add(this.label2);
            this.panelOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutput.Location = new System.Drawing.Point(293, 3);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(284, 386);
            this.panelOutput.TabIndex = 1;
            // 
            // labelStringResult
            // 
            this.labelStringResult.BackColor = System.Drawing.Color.White;
            this.labelStringResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStringResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStringResult.Location = new System.Drawing.Point(0, 28);
            this.labelStringResult.Name = "labelStringResult";
            this.labelStringResult.Padding = new System.Windows.Forms.Padding(14);
            this.labelStringResult.Size = new System.Drawing.Size(284, 358);
            this.labelStringResult.TabIndex = 4;
            this.labelStringResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelStringResult.Visible = false;
            // 
            // propertyGridResult
            // 
            this.propertyGridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridResult.HelpVisible = false;
            this.propertyGridResult.Location = new System.Drawing.Point(0, 28);
            this.propertyGridResult.Name = "propertyGridResult";
            this.propertyGridResult.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGridResult.Size = new System.Drawing.Size(284, 358);
            this.propertyGridResult.TabIndex = 1;
            this.propertyGridResult.ToolbarVisible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Return Object";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonInvoke
            // 
            this.buttonInvoke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInvoke.Location = new System.Drawing.Point(464, 413);
            this.buttonInvoke.Name = "buttonInvoke";
            this.buttonInvoke.Size = new System.Drawing.Size(129, 27);
            this.buttonInvoke.TabIndex = 0;
            this.buttonInvoke.Text = "Invoke";
            this.buttonInvoke.UseVisualStyleBackColor = true;
            this.buttonInvoke.Click += new System.EventHandler(this.buttonInvoke_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.panelInput, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panelOutput, 1, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(14, 14);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(580, 392);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // InvokeMethodDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 453);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.buttonInvoke);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvokeMethodDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoke Method (Advanced)";
            this.panelInput.ResumeLayout(false);
            this.panelOutput.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.PropertyGrid propertyGridMethodInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelOutput;
        private System.Windows.Forms.PropertyGrid propertyGridResult;
        private System.Windows.Forms.Button buttonInvoke;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelStringResult;
    }
}