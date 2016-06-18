namespace WinFormsSandbox.Forms
{ 
    partial class MethodsQuickView
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
            this.comboMethods = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonInvokeMethod = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboMethods
            // 
            this.tableLayoutPanel.SetColumnSpan(this.comboMethods, 2);
            this.comboMethods.DisplayMember = "Value";
            this.comboMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethods.FormattingEnabled = true;
            this.comboMethods.Location = new System.Drawing.Point(3, 32);
            this.comboMethods.Name = "comboMethods";
            this.comboMethods.Size = new System.Drawing.Size(344, 23);
            this.comboMethods.Sorted = true;
            this.comboMethods.TabIndex = 1;
            this.comboMethods.ValueMember = "Key";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.comboMethods, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonInvokeMethod, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxFind, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(350, 95);
            this.tableLayoutPanel.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 21;
            this.label2.Text = "Find by name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonInvokeMethod
            // 
            this.tableLayoutPanel.SetColumnSpan(this.buttonInvokeMethod, 2);
            this.buttonInvokeMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInvokeMethod.Location = new System.Drawing.Point(3, 61);
            this.buttonInvokeMethod.Name = "buttonInvokeMethod";
            this.buttonInvokeMethod.Size = new System.Drawing.Size(344, 35);
            this.buttonInvokeMethod.TabIndex = 2;
            this.buttonInvokeMethod.Text = "Invoke";
            this.buttonInvokeMethod.UseVisualStyleBackColor = true;
            this.buttonInvokeMethod.Click += new System.EventHandler(this.buttonInvokeMethod_Click);
            // 
            // textBoxFind
            // 
            this.textBoxFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFind.Location = new System.Drawing.Point(82, 3);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(265, 23);
            this.textBoxFind.TabIndex = 0;
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            // 
            // MethodsQuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Methods";
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MethodsQuickView";
            this.Size = new System.Drawing.Size(350, 156);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboMethods;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonInvokeMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFind;
    }
}
