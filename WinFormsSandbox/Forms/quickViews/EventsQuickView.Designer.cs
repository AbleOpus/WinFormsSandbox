namespace WinFormsSandbox.Forms
{
    partial class EventsQuickView
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
            System.Windows.Forms.Label label1;
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListEvents = new System.Windows.Forms.CheckedListBox();
            this.buttonNone = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 33);
            label1.TabIndex = 13;
            label1.Text = "Select";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.checkedListEvents, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonNone, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonAll, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(322, 245);
            this.tableLayoutPanel.TabIndex = 14;
            // 
            // checkedListEvents
            // 
            this.tableLayoutPanel.SetColumnSpan(this.checkedListEvents, 3);
            this.checkedListEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListEvents.FormattingEnabled = true;
            this.checkedListEvents.IntegralHeight = false;
            this.checkedListEvents.Location = new System.Drawing.Point(3, 36);
            this.checkedListEvents.Name = "checkedListEvents";
            this.checkedListEvents.Size = new System.Drawing.Size(316, 174);
            this.checkedListEvents.Sorted = true;
            this.checkedListEvents.TabIndex = 3;
            // 
            // buttonNone
            // 
            this.buttonNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNone.Location = new System.Drawing.Point(186, 3);
            this.buttonNone.Name = "buttonNone";
            this.buttonNone.Size = new System.Drawing.Size(133, 27);
            this.buttonNone.TabIndex = 1;
            this.buttonNone.Text = "&None";
            this.buttonNone.UseVisualStyleBackColor = true;
            this.buttonNone.Click += new System.EventHandler(this.buttonNone_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAll.Location = new System.Drawing.Point(47, 3);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(133, 27);
            this.buttonAll.TabIndex = 0;
            this.buttonAll.Text = "&All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelDescription, 3);
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescription.Location = new System.Drawing.Point(3, 216);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 14);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(316, 15);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "No Description";
            // 
            // EventsQuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Events";
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "EventsQuickView";
            this.Size = new System.Drawing.Size(322, 275);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonNone;
        private System.Windows.Forms.CheckedListBox checkedListEvents;
        private System.Windows.Forms.Label labelDescription;
    }
}
