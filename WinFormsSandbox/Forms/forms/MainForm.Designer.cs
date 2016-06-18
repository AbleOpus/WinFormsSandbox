using System;

namespace WinFormsSandbox.Forms
{
    partial class MainForm
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
            if (disposing)
            {
                foreach (IDisposable disposable in panelControlParent.Controls)
                    disposable.Dispose();
            }
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.SplitContainer splitContainer1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelQuickViews = new System.Windows.Forms.Panel();
            this.quickViewEvents = new WinFormsSandbox.Forms.EventsQuickView();
            this.quickViewCustomCode = new WinFormsSandbox.Forms.CustomCodeQuickView();
            this.quickViewMethods = new WinFormsSandbox.Forms.MethodsQuickView();
            this.quickViewProperties = new WinFormsSandbox.Forms.PropertiesQuickView();
            this.quickViewLoadObjects = new WinFormsSandbox.Forms.LoadObjectsQuickView();
            this.quickViewLoadAssem = new WinFormsSandbox.Forms.LoadAssemQuickView();
            this.tablePanelExpandColapse = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExpandAll = new System.Windows.Forms.Button();
            this.buttonCollapseAll = new System.Windows.Forms.Button();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.splitContainerCenter = new System.Windows.Forms.SplitContainer();
            this.panelControlParent = new WinFormsSandbox.Forms.ControlHouser();
            this.toolStripLoadedControl = new System.Windows.Forms.ToolStrip();
            this.buttonDockFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonDockNone = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonShowFailsafe = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonUnload = new System.Windows.Forms.ToolStripButton();
            this.labelObjectStatus = new System.Windows.Forms.ToolStripLabel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.listViewErrors = new WinFormsSandbox.Forms.FillListView();
            this.clmErrorCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxInfo = new WinFormsSandbox.Forms.CSharpTextBox();
            this.toolStripInfo = new WinFormsSandbox.Forms.IllumToolStrip();
            this.labelInfoCaption = new System.Windows.Forms.ToolStripLabel();
            this.labelMoreInfoLink = new System.Windows.Forms.ToolStripLabel();
            this.dataGridEventLog = new System.Windows.Forms.DataGridView();
            this.clmFireTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClearEvents = new System.Windows.Forms.Button();
            this.toolStripEvents = new WinFormsSandbox.Forms.IllumToolStrip();
            this.labelEvents = new System.Windows.Forms.ToolStripLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            this.panelQuickViews.SuspendLayout();
            this.tablePanelExpandColapse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).BeginInit();
            this.splitContainerCenter.Panel1.SuspendLayout();
            this.splitContainerCenter.Panel2.SuspendLayout();
            this.splitContainerCenter.SuspendLayout();
            this.toolStripLoadedControl.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxInfo)).BeginInit();
            this.toolStripInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEventLog)).BeginInit();
            this.toolStripEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(this.panelQuickViews);
            splitContainer1.Panel1.Controls.Add(this.tablePanelExpandColapse);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(this.splitContainerRight);
            splitContainer1.Size = new System.Drawing.Size(1108, 588);
            splitContainer1.SplitterDistance = 312;
            splitContainer1.TabIndex = 5;
            // 
            // panelQuickViews
            // 
            this.panelQuickViews.AutoScroll = true;
            this.panelQuickViews.BackColor = System.Drawing.SystemColors.Control;
            this.panelQuickViews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuickViews.Controls.Add(this.quickViewEvents);
            this.panelQuickViews.Controls.Add(this.quickViewCustomCode);
            this.panelQuickViews.Controls.Add(this.quickViewMethods);
            this.panelQuickViews.Controls.Add(this.quickViewProperties);
            this.panelQuickViews.Controls.Add(this.quickViewLoadObjects);
            this.panelQuickViews.Controls.Add(this.quickViewLoadAssem);
            this.panelQuickViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuickViews.Location = new System.Drawing.Point(0, 27);
            this.panelQuickViews.Name = "panelQuickViews";
            this.panelQuickViews.Size = new System.Drawing.Size(312, 561);
            this.panelQuickViews.TabIndex = 0;
            // 
            // quickViewEvents
            // 
            this.quickViewEvents.Caption = "Events";
            this.quickViewEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.quickViewEvents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickViewEvents.InitialExpandHeight = 350;
            this.quickViewEvents.Location = new System.Drawing.Point(0, 145);
            this.quickViewEvents.Name = "quickViewEvents";
            this.quickViewEvents.Size = new System.Drawing.Size(310, 29);
            this.quickViewEvents.TabIndex = 12;
            this.quickViewEvents.SelectedEventChanged += new System.EventHandler(this.UpdateEventsInfoHandler);
            // 
            // quickViewCustomCode
            // 
            this.quickViewCustomCode.Caption = "Custom Code";
            this.quickViewCustomCode.CustomCode = "";
            this.quickViewCustomCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.quickViewCustomCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickViewCustomCode.InitialExpandHeight = 333;
            this.quickViewCustomCode.Location = new System.Drawing.Point(0, 116);
            this.quickViewCustomCode.Name = "quickViewCustomCode";
            this.quickViewCustomCode.Size = new System.Drawing.Size(310, 29);
            this.quickViewCustomCode.TabIndex = 11;
            this.quickViewCustomCode.InvokeButtonClick += new System.EventHandler(this.quickViewCustomCode_ExecuteButtonClick);
            // 
            // quickViewMethods
            // 
            this.quickViewMethods.Caption = "Methods";
            this.quickViewMethods.Dock = System.Windows.Forms.DockStyle.Top;
            this.quickViewMethods.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickViewMethods.InitialExpandHeight = 200;
            this.quickViewMethods.Location = new System.Drawing.Point(0, 87);
            this.quickViewMethods.Name = "quickViewMethods";
            this.quickViewMethods.Size = new System.Drawing.Size(310, 29);
            this.quickViewMethods.TabIndex = 10;
            this.quickViewMethods.InvokeButtonClick += new System.EventHandler<System.Reflection.MethodInfo>(this.quickViewMethods_InvokeButtonClick);
            this.quickViewMethods.SelectedMethodChanged += new System.EventHandler(this.UpdateMethodsInfoHandler);
            this.quickViewMethods.MethodComboFocused += new System.EventHandler(this.UpdateMethodsInfoHandler);
            // 
            // quickViewProperties
            // 
            this.quickViewProperties.Caption = "Properties";
            this.quickViewProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.quickViewProperties.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickViewProperties.InitialExpandHeight = 342;
            this.quickViewProperties.Location = new System.Drawing.Point(0, 58);
            this.quickViewProperties.Name = "quickViewProperties";
            this.quickViewProperties.Size = new System.Drawing.Size(310, 29);
            this.quickViewProperties.TabIndex = 9;
            this.quickViewProperties.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.UpdatePropertiesInfoHandler);
            // 
            // quickViewLoadObjects
            // 
            this.quickViewLoadObjects.Caption = "Load Objects";
            this.quickViewLoadObjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.quickViewLoadObjects.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickViewLoadObjects.Location = new System.Drawing.Point(0, 29);
            this.quickViewLoadObjects.Name = "quickViewLoadObjects";
            this.quickViewLoadObjects.Size = new System.Drawing.Size(310, 29);
            this.quickViewLoadObjects.TabIndex = 8;
            this.quickViewLoadObjects.ObjectLoaded += new System.EventHandler<object>(this.quickViewLoadObjects_ObjectLoaded);
            // 
            // quickViewLoadAssem
            // 
            this.quickViewLoadAssem.Caption = "Load Assemblies";
            this.quickViewLoadAssem.Dock = System.Windows.Forms.DockStyle.Top;
            this.quickViewLoadAssem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.quickViewLoadAssem.Location = new System.Drawing.Point(0, 0);
            this.quickViewLoadAssem.Name = "quickViewLoadAssem";
            this.quickViewLoadAssem.Size = new System.Drawing.Size(310, 29);
            this.quickViewLoadAssem.TabIndex = 7;
            this.quickViewLoadAssem.LoadAssembliesButtonClick += new System.EventHandler(this.quickViewLoadAssem_LoadAssembliesButtonClick);
            this.quickViewLoadAssem.AssembliesLoaded += new System.EventHandler(this.quickViewLoadAssem_AssembliesLoaded);
            // 
            // tablePanelExpandColapse
            // 
            this.tablePanelExpandColapse.AutoSize = true;
            this.tablePanelExpandColapse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablePanelExpandColapse.ColumnCount = 2;
            this.tablePanelExpandColapse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelExpandColapse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelExpandColapse.Controls.Add(this.buttonExpandAll, 0, 0);
            this.tablePanelExpandColapse.Controls.Add(this.buttonCollapseAll, 1, 0);
            this.tablePanelExpandColapse.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanelExpandColapse.Location = new System.Drawing.Point(0, 0);
            this.tablePanelExpandColapse.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanelExpandColapse.Name = "tablePanelExpandColapse";
            this.tablePanelExpandColapse.RowCount = 1;
            this.tablePanelExpandColapse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelExpandColapse.Size = new System.Drawing.Size(312, 27);
            this.tablePanelExpandColapse.TabIndex = 15;
            // 
            // buttonExpandAll
            // 
            this.buttonExpandAll.AutoSize = true;
            this.buttonExpandAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExpandAll.BackColor = System.Drawing.SystemColors.Control;
            this.buttonExpandAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExpandAll.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpandAll.Image = global::WinFormsSandbox.Properties.Resources.Expand;
            this.buttonExpandAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExpandAll.Location = new System.Drawing.Point(0, 0);
            this.buttonExpandAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExpandAll.Name = "buttonExpandAll";
            this.buttonExpandAll.Size = new System.Drawing.Size(156, 27);
            this.buttonExpandAll.TabIndex = 1;
            this.buttonExpandAll.Text = "Expand All";
            this.buttonExpandAll.UseVisualStyleBackColor = false;
            this.buttonExpandAll.Click += new System.EventHandler(this.buttonExpandAll_Click);
            // 
            // buttonCollapseAll
            // 
            this.buttonCollapseAll.AutoSize = true;
            this.buttonCollapseAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCollapseAll.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCollapseAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCollapseAll.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollapseAll.Image = global::WinFormsSandbox.Properties.Resources.Collapse;
            this.buttonCollapseAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCollapseAll.Location = new System.Drawing.Point(156, 0);
            this.buttonCollapseAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCollapseAll.Name = "buttonCollapseAll";
            this.buttonCollapseAll.Size = new System.Drawing.Size(156, 27);
            this.buttonCollapseAll.TabIndex = 1;
            this.buttonCollapseAll.Text = "Colapse All";
            this.buttonCollapseAll.UseVisualStyleBackColor = false;
            this.buttonCollapseAll.Click += new System.EventHandler(this.buttonCollapseAll_Click);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.splitContainerCenter);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.dataGridEventLog);
            this.splitContainerRight.Panel2.Controls.Add(this.buttonClearEvents);
            this.splitContainerRight.Panel2.Controls.Add(this.toolStripEvents);
            this.splitContainerRight.Size = new System.Drawing.Size(792, 588);
            this.splitContainerRight.SplitterDistance = 491;
            this.splitContainerRight.TabIndex = 6;
            this.splitContainerRight.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerRight_SplitterMoved);
            // 
            // splitContainerCenter
            // 
            this.splitContainerCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCenter.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCenter.Name = "splitContainerCenter";
            this.splitContainerCenter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCenter.Panel1
            // 
            this.splitContainerCenter.Panel1.Controls.Add(this.panelControlParent);
            this.splitContainerCenter.Panel1.Controls.Add(this.toolStripLoadedControl);
            // 
            // splitContainerCenter.Panel2
            // 
            this.splitContainerCenter.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerCenter.Panel2.Controls.Add(this.panelInfo);
            this.splitContainerCenter.Panel2.Controls.Add(this.toolStripInfo);
            this.splitContainerCenter.Size = new System.Drawing.Size(491, 588);
            this.splitContainerCenter.SplitterDistance = 265;
            this.splitContainerCenter.TabIndex = 6;
            // 
            // panelControlParent
            // 
            this.panelControlParent.BackColor = System.Drawing.SystemColors.Control;
            this.panelControlParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControlParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlParent.Location = new System.Drawing.Point(0, 25);
            this.panelControlParent.Name = "panelControlParent";
            this.panelControlParent.Size = new System.Drawing.Size(491, 240);
            this.panelControlParent.TabIndex = 6;
            this.toolTip.SetToolTip(this.panelControlParent, "This is the sandbox panel, where the loaded object will be displayed\r\nif it is a " +
        "placeable component. A red stroke will appear around the\r\ncomponent.");
            // 
            // toolStripLoadedControl
            // 
            this.toolStripLoadedControl.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripLoadedControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDockFill,
            this.toolStripSeparator1,
            this.buttonDockNone,
            this.toolStripSeparator2,
            this.buttonShowFailsafe,
            this.toolStripSeparator3,
            this.buttonUnload,
            this.labelObjectStatus});
            this.toolStripLoadedControl.Location = new System.Drawing.Point(0, 0);
            this.toolStripLoadedControl.Name = "toolStripLoadedControl";
            this.toolStripLoadedControl.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripLoadedControl.Size = new System.Drawing.Size(491, 25);
            this.toolStripLoadedControl.TabIndex = 7;
            // 
            // buttonDockFill
            // 
            this.buttonDockFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonDockFill.Image = ((System.Drawing.Image)(resources.GetObject("buttonDockFill.Image")));
            this.buttonDockFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDockFill.Name = "buttonDockFill";
            this.buttonDockFill.Size = new System.Drawing.Size(56, 22);
            this.buttonDockFill.Text = "Dock Fill";
            this.buttonDockFill.ToolTipText = "Set the loaded control to fill its parent.";
            this.buttonDockFill.Click += new System.EventHandler(this.buttonDockFill_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonDockNone
            // 
            this.buttonDockNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonDockNone.Image = ((System.Drawing.Image)(resources.GetObject("buttonDockNone.Image")));
            this.buttonDockNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDockNone.Name = "buttonDockNone";
            this.buttonDockNone.Size = new System.Drawing.Size(70, 22);
            this.buttonDockNone.Text = "Dock None";
            this.buttonDockNone.ToolTipText = "Set the loaded control to undock in its parent container.";
            this.buttonDockNone.Click += new System.EventHandler(this.buttonDockNone_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonShowFailsafe
            // 
            this.buttonShowFailsafe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonShowFailsafe.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowFailsafe.Image")));
            this.buttonShowFailsafe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowFailsafe.Name = "buttonShowFailsafe";
            this.buttonShowFailsafe.Size = new System.Drawing.Size(82, 22);
            this.buttonShowFailsafe.Text = "Show Failsafe";
            this.buttonShowFailsafe.ToolTipText = "Attempts to make the component visible within the sandbox panel.";
            this.buttonShowFailsafe.Click += new System.EventHandler(this.buttonShowFailsafe_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonUnload
            // 
            this.buttonUnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonUnload.Image = ((System.Drawing.Image)(resources.GetObject("buttonUnload.Image")));
            this.buttonUnload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUnload.Name = "buttonUnload";
            this.buttonUnload.Size = new System.Drawing.Size(49, 22);
            this.buttonUnload.Text = "Unload";
            this.buttonUnload.ToolTipText = "Disposes of the loaded object if it is a disposable type.";
            this.buttonUnload.Click += new System.EventHandler(this.buttonUnload_Click);
            // 
            // labelObjectStatus
            // 
            this.labelObjectStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelObjectStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelObjectStatus.Name = "labelObjectStatus";
            this.labelObjectStatus.Size = new System.Drawing.Size(29, 22);
            this.labelObjectStatus.Text = "N/A";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.panelInfo.Controls.Add(this.listViewErrors);
            this.panelInfo.Controls.Add(this.textBoxInfo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(0, 25);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(6);
            this.panelInfo.Size = new System.Drawing.Size(491, 294);
            this.panelInfo.TabIndex = 14;
            // 
            // listViewErrors
            // 
            this.listViewErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmErrorCode,
            this.clmLine,
            this.clmMessage});
            this.listViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewErrors.Location = new System.Drawing.Point(6, 6);
            this.listViewErrors.Name = "listViewErrors";
            this.listViewErrors.Size = new System.Drawing.Size(479, 282);
            this.listViewErrors.TabIndex = 14;
            this.listViewErrors.UseCompatibleStateImageBehavior = false;
            this.listViewErrors.View = System.Windows.Forms.View.Details;
            this.listViewErrors.Visible = false;
            // 
            // clmErrorCode
            // 
            this.clmErrorCode.Text = "Code";
            this.clmErrorCode.Width = 73;
            // 
            // clmLine
            // 
            this.clmLine.Text = "Line";
            this.clmLine.Width = 55;
            // 
            // clmMessage
            // 
            this.clmMessage.Text = "Message";
            this.clmMessage.Width = 347;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.AutoScrollMinSize = new System.Drawing.Size(128, 18);
            this.textBoxInfo.BackBrush = null;
            this.textBoxInfo.CharHeight = 18;
            this.textBoxInfo.CharWidth = 9;
            this.textBoxInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxInfo.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBoxInfo.ForeColor = System.Drawing.Color.Black;
            this.textBoxInfo.IndentBackColor = System.Drawing.Color.White;
            this.textBoxInfo.IsReplaceMode = false;
            this.textBoxInfo.Language = FastColoredTextBoxNS.Language.CSharp;
            this.textBoxInfo.LeftBracket = '(';
            this.textBoxInfo.LineNumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.textBoxInfo.Location = new System.Drawing.Point(6, 6);
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Paddings = new System.Windows.Forms.Padding(0);
            this.textBoxInfo.RightBracket = ')';
            this.textBoxInfo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBoxInfo.ShowLineNumbers = false;
            this.textBoxInfo.Size = new System.Drawing.Size(479, 282);
            this.textBoxInfo.TabIndex = 15;
            this.textBoxInfo.Text = "cSharpTextBox1";
            this.textBoxInfo.Zoom = 100;
            // 
            // toolStripInfo
            // 
            this.toolStripInfo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripInfo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelInfoCaption,
            this.labelMoreInfoLink});
            this.toolStripInfo.Location = new System.Drawing.Point(0, 0);
            this.toolStripInfo.Name = "toolStripInfo";
            this.toolStripInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripInfo.Size = new System.Drawing.Size(491, 25);
            this.toolStripInfo.TabIndex = 12;
            this.toolStripInfo.Click += new System.EventHandler(this.toolStripInfo_DoubleClick);
            // 
            // labelInfoCaption
            // 
            this.labelInfoCaption.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.labelInfoCaption.Name = "labelInfoCaption";
            this.labelInfoCaption.Size = new System.Drawing.Size(70, 22);
            this.labelInfoCaption.Text = "Information";
            // 
            // labelMoreInfoLink
            // 
            this.labelMoreInfoLink.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelMoreInfoLink.IsLink = true;
            this.labelMoreInfoLink.Name = "labelMoreInfoLink";
            this.labelMoreInfoLink.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.labelMoreInfoLink.Size = new System.Drawing.Size(95, 22);
            this.labelMoreInfoLink.Text = "Get More Info...";
            this.labelMoreInfoLink.Click += new System.EventHandler(this.labelMoreInfoLink_Click);
            // 
            // dataGridEventLog
            // 
            this.dataGridEventLog.AllowUserToAddRows = false;
            this.dataGridEventLog.AllowUserToDeleteRows = false;
            this.dataGridEventLog.AllowUserToResizeRows = false;
            this.dataGridEventLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEventLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridEventLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEventLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmFireTime,
            this.clmName});
            this.dataGridEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEventLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridEventLog.Location = new System.Drawing.Point(0, 25);
            this.dataGridEventLog.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridEventLog.Name = "dataGridEventLog";
            this.dataGridEventLog.RowHeadersVisible = false;
            this.dataGridEventLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEventLog.ShowEditingIcon = false;
            this.dataGridEventLog.Size = new System.Drawing.Size(297, 536);
            this.dataGridEventLog.TabIndex = 15;
            // 
            // clmFireTime
            // 
            this.clmFireTime.HeaderText = "Fire Time";
            this.clmFireTime.Name = "clmFireTime";
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // buttonClearEvents
            // 
            this.buttonClearEvents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonClearEvents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonClearEvents.Location = new System.Drawing.Point(0, 561);
            this.buttonClearEvents.Name = "buttonClearEvents";
            this.buttonClearEvents.Size = new System.Drawing.Size(297, 27);
            this.buttonClearEvents.TabIndex = 16;
            this.buttonClearEvents.Text = "Clear";
            this.buttonClearEvents.UseVisualStyleBackColor = true;
            this.buttonClearEvents.Click += new System.EventHandler(this.buttonClearEvents_Click);
            // 
            // toolStripEvents
            // 
            this.toolStripEvents.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripEvents.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelEvents});
            this.toolStripEvents.Location = new System.Drawing.Point(0, 0);
            this.toolStripEvents.Name = "toolStripEvents";
            this.toolStripEvents.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripEvents.Size = new System.Drawing.Size(297, 25);
            this.toolStripEvents.TabIndex = 14;
            this.toolStripEvents.Click += new System.EventHandler(this.toolStripEvents_Click);
            // 
            // labelEvents
            // 
            this.labelEvents.Margin = new System.Windows.Forms.Padding(3);
            this.labelEvents.Name = "labelEvents";
            this.labelEvents.Size = new System.Drawing.Size(41, 19);
            this.labelEvents.Text = "Events";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 588);
            this.Controls.Add(splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "WinForms Sandbox";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            this.panelQuickViews.ResumeLayout(false);
            this.tablePanelExpandColapse.ResumeLayout(false);
            this.tablePanelExpandColapse.PerformLayout();
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            this.splitContainerRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.splitContainerCenter.Panel1.ResumeLayout(false);
            this.splitContainerCenter.Panel1.PerformLayout();
            this.splitContainerCenter.Panel2.ResumeLayout(false);
            this.splitContainerCenter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).EndInit();
            this.splitContainerCenter.ResumeLayout(false);
            this.toolStripLoadedControl.ResumeLayout(false);
            this.toolStripLoadedControl.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxInfo)).EndInit();
            this.toolStripInfo.ResumeLayout(false);
            this.toolStripInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEventLog)).EndInit();
            this.toolStripEvents.ResumeLayout(false);
            this.toolStripEvents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelQuickViews;
        private EventsQuickView quickViewEvents;
        private CustomCodeQuickView quickViewCustomCode;
        private MethodsQuickView quickViewMethods;
        private PropertiesQuickView quickViewProperties;
        private LoadObjectsQuickView quickViewLoadObjects;
        private LoadAssemQuickView quickViewLoadAssem;
        private System.Windows.Forms.TableLayoutPanel tablePanelExpandColapse;
        private System.Windows.Forms.Button buttonExpandAll;
        private System.Windows.Forms.Button buttonCollapseAll;
        private ControlHouser panelControlParent;
        private IllumToolStrip toolStripInfo;
        private System.Windows.Forms.ToolStripLabel labelInfoCaption;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.ToolStrip toolStripLoadedControl;
        private System.Windows.Forms.ToolStripButton buttonDockFill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonDockNone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonShowFailsafe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton buttonUnload;
        private System.Windows.Forms.ToolStripLabel labelObjectStatus;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer splitContainerCenter;
        private System.Windows.Forms.ToolStripLabel labelMoreInfoLink;
        private FillListView listViewErrors;
        private System.Windows.Forms.ColumnHeader clmErrorCode;
        private System.Windows.Forms.ColumnHeader clmLine;
        private System.Windows.Forms.ColumnHeader clmMessage;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.DataGridView dataGridEventLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFireTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.Button buttonClearEvents;
        private IllumToolStrip toolStripEvents;
        private System.Windows.Forms.ToolStripLabel labelEvents;
        private CSharpTextBox textBoxInfo;
    }
}