namespace WinFormsSandbox.Forms
{
    partial class LoadObjectsQuickView
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.comboCtor = new System.Windows.Forms.ComboBox();
            this.buttonLoadControl = new System.Windows.Forms.Button();
            this.comboTypes = new System.Windows.Forms.ComboBox();
            this.comboLoadedAssemblies = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Left;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            label2.Size = new System.Drawing.Size(61, 17);
            label2.TabIndex = 6;
            label2.Text = "Assembly:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Left;
            label1.Location = new System.Drawing.Point(3, 46);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 2, 27, 0);
            label1.Size = new System.Drawing.Size(62, 17);
            label1.TabIndex = 9;
            label1.Text = "Type:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Left;
            label3.Location = new System.Drawing.Point(3, 92);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(0, 2, 34, 0);
            label3.Size = new System.Drawing.Size(112, 17);
            label3.TabIndex = 11;
            label3.Text = "Constructors:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.comboCtor, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonLoadControl, 0, 6);
            this.tableLayoutPanel.Controls.Add(label3, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.comboTypes, 0, 3);
            this.tableLayoutPanel.Controls.Add(label1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.comboLoadedAssemblies, 0, 1);
            this.tableLayoutPanel.Controls.Add(label2, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(332, 179);
            this.tableLayoutPanel.TabIndex = 14;
            // 
            // comboCtor
            // 
            this.tableLayoutPanel.SetColumnSpan(this.comboCtor, 2);
            this.comboCtor.DisplayMember = "Value";
            this.comboCtor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboCtor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCtor.FormattingEnabled = true;
            this.comboCtor.Location = new System.Drawing.Point(3, 112);
            this.comboCtor.Name = "comboCtor";
            this.comboCtor.Size = new System.Drawing.Size(326, 23);
            this.comboCtor.Sorted = true;
            this.comboCtor.TabIndex = 2;
            this.comboCtor.ValueMember = "Key";
            // 
            // buttonLoadControl
            // 
            this.tableLayoutPanel.SetColumnSpan(this.buttonLoadControl, 2);
            this.buttonLoadControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoadControl.Image = global::WinFormsSandbox.Properties.Resources.Instantiate;
            this.buttonLoadControl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadControl.Location = new System.Drawing.Point(3, 141);
            this.buttonLoadControl.Name = "buttonLoadControl";
            this.buttonLoadControl.Size = new System.Drawing.Size(326, 35);
            this.buttonLoadControl.TabIndex = 3;
            this.buttonLoadControl.Text = "&Create Instance";
            this.buttonLoadControl.UseVisualStyleBackColor = true;
            this.buttonLoadControl.Click += new System.EventHandler(this.buttonLoadControl_Click);
            // 
            // comboTypes
            // 
            this.comboTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel.SetColumnSpan(this.comboTypes, 2);
            this.comboTypes.DisplayMember = "Value";
            this.comboTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.comboTypes.FormattingEnabled = true;
            this.comboTypes.Location = new System.Drawing.Point(3, 66);
            this.comboTypes.Name = "comboTypes";
            this.comboTypes.Size = new System.Drawing.Size(326, 23);
            this.comboTypes.Sorted = true;
            this.comboTypes.TabIndex = 1;
            this.comboTypes.ValueMember = "Key";
            this.comboTypes.SelectedValueChanged += new System.EventHandler(this.comboTypes_SelectedIndexChanged);
            // 
            // comboLoadedAssemblies
            // 
            this.tableLayoutPanel.SetColumnSpan(this.comboLoadedAssemblies, 2);
            this.comboLoadedAssemblies.DisplayMember = "Value";
            this.comboLoadedAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboLoadedAssemblies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLoadedAssemblies.FormattingEnabled = true;
            this.comboLoadedAssemblies.Location = new System.Drawing.Point(3, 20);
            this.comboLoadedAssemblies.Name = "comboLoadedAssemblies";
            this.comboLoadedAssemblies.Size = new System.Drawing.Size(326, 23);
            this.comboLoadedAssemblies.Sorted = true;
            this.comboLoadedAssemblies.TabIndex = 0;
            this.comboLoadedAssemblies.ValueMember = "Key";
            this.comboLoadedAssemblies.SelectedIndexChanged += new System.EventHandler(this.comboLoadedAssemblies_SelectedIndexChanged);
            // 
            // LoadObjectsQuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Load Objects";
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "LoadObjectsQuickView";
            this.Size = new System.Drawing.Size(332, 308);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ComboBox comboLoadedAssemblies;
        private System.Windows.Forms.ComboBox comboTypes;
        private System.Windows.Forms.ComboBox comboCtor;
        private System.Windows.Forms.Button buttonLoadControl;
    }
}
