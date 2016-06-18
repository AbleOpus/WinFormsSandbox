namespace WinFormsSandbox.Forms
{
    partial class CustomCodeQuickView
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
            System.Windows.Forms.Label label5;
            this.buttonExecute = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxCode = new WinFormsSandbox.Forms.CSharpTextBox();
            label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.Location = new System.Drawing.Point(3, 0);
            label5.Name = "label5";
            label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            label5.Size = new System.Drawing.Size(335, 25);
            label5.TabIndex = 15;
            label5.Text = "Refer to the object as \"obj\"";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonExecute.Location = new System.Drawing.Point(3, 173);
            this.buttonExecute.Margin = new System.Windows.Forms.Padding(3, 3, 3, 14);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(335, 35);
            this.buttonExecute.TabIndex = 1;
            this.buttonExecute.Text = "&Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.buttonExecute, 0, 2);
            this.tableLayoutPanel.Controls.Add(label5, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxCode, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(341, 222);
            this.tableLayoutPanel.TabIndex = 15;
            // 
            // textBoxCode
            // 
            this.textBoxCode.AutoScrollMinSize = new System.Drawing.Size(155, 18);
            this.textBoxCode.BackBrush = null;
            this.textBoxCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCode.CharHeight = 18;
            this.textBoxCode.CharWidth = 9;
            this.textBoxCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCode.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBoxCode.ForeColor = System.Drawing.Color.Black;
            this.textBoxCode.IndentBackColor = System.Drawing.Color.White;
            this.textBoxCode.IsReplaceMode = false;
            this.textBoxCode.Language = FastColoredTextBoxNS.Language.CSharp;
            this.textBoxCode.LeftBracket = '(';
            this.textBoxCode.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.textBoxCode.Location = new System.Drawing.Point(3, 28);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Paddings = new System.Windows.Forms.Padding(0);
            this.textBoxCode.RightBracket = ')';
            this.textBoxCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBoxCode.Size = new System.Drawing.Size(335, 139);
            this.textBoxCode.TabIndex = 0;
            this.textBoxCode.Text = "cSharpTextBox1";
            this.textBoxCode.Zoom = 100;
            // 
            // CustomCodeQuickView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Custom Code";
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "CustomCodeQuickView";
            this.Size = new System.Drawing.Size(341, 252);
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private CSharpTextBox textBoxCode;
    }
}
