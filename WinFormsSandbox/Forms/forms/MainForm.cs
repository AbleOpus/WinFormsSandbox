using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSandbox.Properties;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents the main window of this application.
    /// </summary>
    public partial class MainForm : Form
    {
        private const string NO_OBJ_MSG = "No object loaded.";
        private readonly Point controlStartPos = new Point(20, 20);
        private readonly InfoPanelColapser infoPanelColapser;
        private readonly EventPanelColapser eventPanelColapser;
        private bool awaiting3rdKey;

        private object loadedObject;
        /// <summary>
        /// The object currently loaded into the sandbox.
        /// </summary>
        private object LoadedObject
        {
            get { return loadedObject; }
            set
            {
                loadedObject = value;

                if (value == null)
                {
                    quickViewCustomCode.ExecuteEnabled = false;
                    quickViewMethods.InvokeEnabled = false;
                    SetControlToolstripButtonsEnabled(false);
                    labelObjectStatus.Text = "No object loaded";
                    labelObjectStatus.ForeColor = Color.DarkRed;
                }
                else
                {
                    quickViewCustomCode.ExecuteEnabled = true;
                    quickViewMethods.InvokeEnabled = true;
                    SetControlToolstripButtonsEnabled(true);
                    labelObjectStatus.ForeColor = Color.DarkGreen;
                    string typeString;

                    if (loadedObject is Form)
                        typeString = "Form";
                    else if (loadedObject is Control)
                        typeString = "Control";
                    else if (loadedObject is Component)
                        typeString = "Component";
                    else
                        typeString = "Object";

                    labelObjectStatus.Text = typeString + " Loaded";
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            listViewErrors.SmallImageList = new ImageList();
            listViewErrors.SmallImageList.Images.AddRange(new Image[]
            {
                Resources.Error,
                Resources.Warning
            });

            infoPanelColapser = new InfoPanelColapser(splitContainerCenter);
            eventPanelColapser = new EventPanelColapser(splitContainerRight);
            eventPanelColapser.ControlColapsedToggled += EventPanelColapserOnControlColapsedToggled;
            infoPanelColapser.InitialExpandHeight = splitContainerCenter.Panel2.Height;
            eventPanelColapser.InitialExpandHeight = splitContainerRight.Panel2.Width;
            eventPanelColapser.Colapse();

            quickViewLoadObjects.TypesComboBox.GotFocus += UpdateTypeInfoHandler;
            quickViewLoadObjects.TypesComboBox.SelectedValueChanged += UpdateTypeInfoHandler;
            quickViewLoadObjects.AssembliesComboBox.GotFocus += UpdateAssemblyInfoHandler;
            quickViewLoadObjects.AssembliesComboBox.SelectedIndexChanged += UpdateAssemblyInfoHandler;
            quickViewLoadObjects.ConstructorsComboBox.GotFocus += UpdateConstructorInfoHandler;
            quickViewLoadObjects.ConstructorsComboBox.SelectedIndexChanged += UpdateConstructorInfoHandler;

            if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                LoadedObject = null;
                LoadSettingsAndDefaults();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> that contains the event data. </param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyData)
            {
                case Keys.F1:
                    LookupSelectionOnWeb();
                    break;

                case Keys.F5:
                    if (loadedObject != null)
                        ExecuteCustomCode();
                    break;

                case Keys.Control | Keys.M:
                    awaiting3rdKey = true;
                    break;

                case Keys.L | Keys.Control:
                case Keys.L:
                    if (awaiting3rdKey)
                    {

                        ToggleColapseAllQuickViews();
                        awaiting3rdKey = false;
                        e.SuppressKeyPress = true;
                    }
                    break;

                default:
                    awaiting3rdKey = false;
                    break;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Closing"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data. </param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Default.LastAssemblyIndex = quickViewLoadObjects.AssembliesComboBox.SelectedIndex;
            Settings.Default.LastCtorIndex = quickViewLoadObjects.ConstructorsComboBox.SelectedIndex;
            Settings.Default.LastTypeIndex = quickViewLoadObjects.TypesComboBox.SelectedIndex;
            Settings.Default.LoadObjectHeight = quickViewLoadObjects.Height;
            Settings.Default.CustomCodeHeight = quickViewCustomCode.Height;
            Settings.Default.EventsHeight = quickViewEvents.Height;
            Settings.Default.LoadAssemblyHeight = quickViewLoadAssem.Height;
            Settings.Default.MethodsHeight = quickViewMethods.Height;
            Settings.Default.PropertiesHeight = quickViewProperties.Height;
            Settings.Default.LastAssemblyInfoHeight = splitContainerCenter.SplitterDistance;
            Settings.Default.CustomCode = quickViewCustomCode.CustomCode;
            Settings.Default.Save();
            base.OnClosing(e);
        }

        private void EventPanelColapserOnControlColapsedToggled(object sender, bool colapsed)
        {
            if (colapsed && Dock != DockStyle.Left)
            {
                toolStripEvents.Dock = DockStyle.Left;
                toolStripEvents.TextDirection = ToolStripTextDirection.Vertical270;
                buttonClearEvents.Visible = false;
                dataGridEventLog.Visible = false;
                labelEvents.Font = new Font("", 10, FontStyle.Regular);
                splitContainerRight.Panel2.BackColor = toolStripEvents.BackColor;
            }
            else if (!colapsed && Dock != DockStyle.Top)
            {
                toolStripEvents.Dock = DockStyle.Top;
                toolStripEvents.TextDirection = ToolStripTextDirection.Horizontal;
                buttonClearEvents.Visible = true;
                dataGridEventLog.Visible = true;
                labelEvents.Font = Font;
                splitContainerRight.Panel2.BackColor = SystemColors.Control;
            }
        }

        /// <summary>
        /// Looks up the selected content on MSDN.
        /// </summary>
        private void LookupSelectionOnWeb()
        {
            string query;
            string caption = labelInfoCaption.Text.Split(' ')[0];

            if (listViewErrors.Visible && listViewErrors.SelectedItems.Count > 0)
            {
                query = listViewErrors.SelectedItems[0].Text;
            }
            else if (caption == "Method" && quickViewMethods.SelectedMethod != null)
            {
                query = InfoGathering.GetMsdnMethodQuery(quickViewMethods.SelectedMethod);
            }
            else if (caption == "Type" && quickViewLoadObjects.SelectedType != null)
            {
                query = CSharpSourceGen.GetTypeName(quickViewLoadObjects.SelectedType, true);
            }
            else if (caption == "Assembly" && quickViewLoadObjects.SelectedAssembly != null)
            {
                query = quickViewLoadObjects.SelectedAssembly.GetName().Name;
            }
            else if (caption == "Constructor" && quickViewLoadObjects.SelectedConstructor != null)
            {
                query = InfoGathering.GetMsdnConstructorQuery(quickViewLoadObjects.SelectedConstructor);
            }
            else if (caption == "Property" && quickViewProperties.SelectedProperty != null)
            {
                query = InfoGathering.GetMsdnPropertyQuery(quickViewProperties.SelectedProperty);
            }
            else
            {
                Program.ShowError("Select a queryable element first.");
                return;
            }

            InfoGathering.LookupOnMsdn(query);
        }

        /// <summary>
        /// Shows the specified errors in the error window.
        /// </summary>
        /// <param name="errors">The errors to show.</param>
        /// <param name="lineOffset">The line offset to use for selecting the right line
        /// in custom code, if custom code is used.</param>
        private void DisplayErrors(CompilerErrorCollection errors, int lineOffset = 0)
        {
            listViewErrors.Items.Clear();

            foreach (CompilerError error in errors)
            {
                var item = new ListViewItem(error.ErrorNumber, 0);
                item.SubItems.Add((error.Line - lineOffset).ToString());
                item.SubItems.Add(error.ErrorText);
                listViewErrors.Items.Add(item);
            }

            listViewErrors.Visible = true;
            textBoxInfo.Visible = false;
        }

        private void ClearErrors()
        {
            listViewErrors.Items.Clear();
            listViewErrors.Visible = false;
            textBoxInfo.Visible = true;
        }

        private void ToggleColapseAllQuickViews()
        {
            var views = panelQuickViews.Controls.OfType<QuickView>();
            bool shouldColapse = views.Any(v => !v.Colapser.IsColapsed);

            foreach (var view in views)
            {
                if (shouldColapse)
                {
                    view.Colapser.Colapse();
                }
                else
                {
                    view.Colapser.Expand();
                }
            }
        }

        private void LoadSettingsAndDefaults()
        {
            quickViewLoadObjects.Height = Settings.Default.LoadObjectHeight;
            quickViewCustomCode.Height = Settings.Default.CustomCodeHeight;
            quickViewEvents.Height = Settings.Default.EventsHeight;
            quickViewLoadAssem.Height = Settings.Default.LoadAssemblyHeight;
            quickViewMethods.Height = Settings.Default.MethodsHeight;
            quickViewProperties.Height = Settings.Default.PropertiesHeight;
            quickViewCustomCode.CustomCode = Settings.Default.CustomCode;

            if (Settings.Default.LastAssemblyInfoHeight > 0
                && Settings.Default.LastAssemblyInfoHeight < splitContainerCenter.Height)
                splitContainerCenter.SplitterDistance = Settings.Default.LastAssemblyInfoHeight;
        }

        /// <summary>
        /// Sets the Enabled property of all of the <see cref="ToolStripButton"/> in the
        /// <see cref="ToolStrip"/> above the sandbox panel.
        /// </summary>
        /// <param name="enabled"></param>
        private void SetControlToolstripButtonsEnabled(bool enabled)
        {
            foreach (var buttons in toolStripLoadedControl.Items.OfType<ToolStripButton>())
            {
                buttons.Enabled = enabled;
            }
        }

        /// <summary>
        /// Subscribes to all events of the specified object. Unsupported events are ignored.
        /// </summary>
        /// <param name="instance">The object to iterate events on.</param>
        /// <returns>The events that are supported (can be subscribed to).</returns>
        private EventInfo[] SubscribeToAllEvents(object instance)
        {
            var supportedEvents = new List<EventInfo>();
            var eventInfos = instance.GetType().GetEvents();

            foreach (var eventInfo in eventInfos)
            {
                try
                {
                    eventInfo.AddEventHandler(instance, eventInfo.CreateHandler<object, object>((x1, x2) =>
                    {
                        if (quickViewEvents.CheckedEvents.Contains(eventInfo))
                        {
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)delegate
                               {
                                   SubmitEventLog(eventInfo.Name);
                               });
                            }
                            else
                            {
                                SubmitEventLog(eventInfo.Name);
                            }
                        }
                    }));
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                    {
                        if (!(ex.InnerException is NotSupportedException))
                            throw ex.InnerException;
                    }
                    else
                    {
                        throw ex;
                    }

                    continue;
                }

                supportedEvents.Add(eventInfo);
            }

            return supportedEvents.ToArray();
        }

        /// <summary>
        /// Submits an event firing log to the UI.
        /// </summary>
        /// <param name="eventName">The name of the event that fired.</param>
        private void SubmitEventLog(string eventName)
        {
            dataGridEventLog.Rows.Add(DateTime.Now.ToLongTimeString(), eventName);
            dataGridEventLog.ScrollToBottom();
        }

        /// <summary>
        /// Creates a <see cref="Label"/> to indicate that a unplaceable component has been loaded.
        /// </summary>
        private static Label CreateIndicatorLabel(bool component, string instanceDescriptor)
        {
            string temp = component ? "Component" : "Non-component";

            return new Label
            {
                Text = $"{temp} loaded\n{instanceDescriptor}",
                Font = new Font("Consolas", 14, FontStyle.Regular),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.DarkRed
            };
        }

        private void ExecuteCustomCode()
        {
            var results = DynamicUtilities.ExecuteMethodBody(quickViewCustomCode.CustomCode, loadedObject);

            if (results.Errors.HasErrors)
            {
                DisplayErrors(results.Errors, results.CustomCodeOffset);
                infoPanelColapser.Expand();

                quickViewCustomCode.HighlightLines(results.Errors.OfType<CompilerError>()
                    .Select(err => err.Line - results.CustomCodeOffset).ToArray());
            }
            else
            {
                ClearErrors();
            }
        }

        /// <summary>
        /// Sets the information to display in the information window, along with the
        /// caption prefix.
        /// </summary>
        /// <param name="caption">The prefix to appear in the caption.
        /// This comes before the word "Information".</param>
        /// <param name="text">The text to display in the main text area of the information window.</param>
        private void SetInformationText(string caption, string text)
        {
            if (IsHandleCreated && textBoxInfo.IsHandleCreated)
            {
                listViewErrors.Visible = false;
                textBoxInfo.Visible = true;
                labelInfoCaption.Text = caption + " Information";
                textBoxInfo.Text = text;
                textBoxInfo.SelectionStart = 0;
            }
        }

        /// <summary>
        /// Attempts to set the Dock property of the loaded object (if the property exists).
        /// </summary>
        /// <param name="dock">The new Dock value.</param>
        private void TryToSetDockOfObj(DockStyle dock)
        {
            if (LoadedObject == null)
            {
                Program.ShowError(NO_OBJ_MSG);
                return;
            }

            Control control = LoadedObject as Control;

            if (control == null)
            {
                Program.ShowError("This feature only works on Control types.");
            }
            else
            {
                control.Dock = dock;
            }
        }

        /// <summary>
        /// Adjusts the loaded object according to its Type.
        /// </summary>
        private void MakeSpecializedAdjustments()
        {
            // Make form useable as a child control.
            Form form = loadedObject as Form;
            if (form != null)
            {
                form.TopLevel = false;
                form.Show();
                panelControlParent.Controls.Add(form);
                return;
            }

            // Position Control, set its text and name property.
            Control control = loadedObject as Control;
            if (control != null)
            {
                control.Location = controlStartPos;
                control.Name = control.GetType().Name + "1";

                try
                {
                    control.Text = control.Name;
                }
                catch (NotSupportedException) { }

                panelControlParent.Controls.Add(control);
                return;
            }

            var isComponent = loadedObject is Component;

            panelControlParent.Controls.Add(CreateIndicatorLabel
                (isComponent, CSharpSourceGen.GetTypeName(loadedObject.GetType(), true)));
        }

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            foreach (var view in panelQuickViews.Controls.OfType<QuickView>())
                view.Colapser.Expand();
        }

        private void buttonCollapseAll_Click(object sender, EventArgs e)
        {
            foreach (var view in panelQuickViews.Controls.OfType<QuickView>())
                view.Colapser.Colapse();
        }

        private void quickViewLoadAssem_LoadAssembliesButtonClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogOpenFile = new OpenFileDialog())
            {
                if (!String.IsNullOrEmpty(Settings.Default.LastLoadAssembliesDir))
                    dialogOpenFile.InitialDirectory = Settings.Default.LastLoadAssembliesDir;

                dialogOpenFile.Filter = "Direct Link Library|*.DLL|All Files|*.*";
                dialogOpenFile.Multiselect = true;
                dialogOpenFile.Title = "Select assemblies";

                if (dialogOpenFile.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in dialogOpenFile.FileNames)
                    {
                        try
                        {
                           Assembly.LoadFrom(fileName);
                        }
                        catch (Exception ex)
                        {
                            Program.ShowError(
                                $"Failed to load the following assembly:\n{fileName}\n\nException: {ex.Message}.");
                        }
                    }

                    Settings.Default.LastLoadAssembliesDir = dialogOpenFile.InitialDirectory;
                    quickViewLoadObjects.PopulateAssembliesComboBox();
                }
            }
        }

        private void quickViewLoadAssem_AssembliesLoaded(object sender, EventArgs e)
        {
            var selItem = quickViewLoadObjects.SelectedAssembly;
            quickViewLoadObjects.PopulateAssembliesComboBox();
            quickViewLoadObjects.SelectedAssembly = selItem;
        }

        private void quickViewLoadObjects_ObjectLoaded(object sender, object e)
        {
            LoadedObject = e;

            foreach (IDisposable disposable in panelControlParent.Controls)
                disposable.Dispose();

            panelControlParent.Controls.Clear();
            MakeSpecializedAdjustments();
            quickViewProperties.SelectedObject = loadedObject;
            quickViewMethods.Populate(loadedObject.GetType().GetMethods());
            var supported = SubscribeToAllEvents(loadedObject);
            quickViewEvents.PopulateEvents(supported);
        }

        private void quickViewMethods_InvokeButtonClick(object sender, MethodInfo e)
        {
            var selMethod = quickViewMethods.SelectedMethod;
            var parameters = selMethod.GetParameters();
            var returnType = selMethod.ReturnType;

            // Invoke with no prompt/options if no parameters or return value.
            if (returnType == typeof(void) && parameters.Length == 0)
            {
                selMethod.Invoke(loadedObject, null);
            }
            //
            else if (parameters.Length == 0)
            {
                using (var dialog = new MethodReturnValueDialog())
                {
                    object returnVal = selMethod.Invoke(loadedObject, null);
                    dialog.SetReturnObject(returnVal);
                    dialog.ShowDialog();
                }
            }
            else
            {
                using (InvokeMethodDialog dialog = new InvokeMethodDialog())
                {
                    dialog.Object = loadedObject;
                    var errors = dialog.SetupMethod(selMethod);

                    if (errors.HasErrors)
                    {
                        DisplayErrors(errors);
                        return;
                    }

                    dialog.ShowDialog();
                }
            }
        }

        private void quickViewCustomCode_ExecuteButtonClick(object sender, EventArgs e)
        {
            ExecuteCustomCode();
        }

        private void buttonClearEvents_Click(object sender, EventArgs e)
        {
            dataGridEventLog.Rows.Clear();
        }

        private async void UpdateAssemblyInfoHandler(object sender, EventArgs e)
        {
            var selAssem = quickViewLoadObjects.SelectedAssembly;

            if (selAssem != null)
            {
                string content = await InfoGathering.DescribeAssemblyTaskAsync(selAssem);
                SetInformationText("Assembly", content);
            }
        }

        private async void UpdateTypeInfoHandler(object sender, EventArgs e)
        {
            var selType = quickViewLoadObjects.SelectedType;

            if (selType != null)
            {
                string content = await InfoGathering.DescribeTypeTaskAsync(selType);
                SetInformationText("Type", content);
            }
        }

        private async void UpdateMethodsInfoHandler(object sender, EventArgs e)
        {
            var selMethod = quickViewMethods.SelectedMethod;

            if (selMethod != null)
            {
                string content = await InfoGathering.DescribeMethodTaskAsync(selMethod);
                SetInformationText("Method", content);
            }
        }

        private async void UpdateEventsInfoHandler(object sender, EventArgs e)
        {
            if (quickViewEvents.SelectedEvent != null)
            {
                string content = await InfoGathering.DescribeEventTaskAsync
                    (quickViewEvents.SelectedEvent);

                SetInformationText("Event", content);
            }
        }

        private async void UpdatePropertiesInfoHandler(object sender, SelectedGridItemChangedEventArgs e)
        {
            PropertyInfo propertyInfo = quickViewProperties.SelectedProperty;

            if (propertyInfo != null)
            {
                string content = await InfoGathering.DescribePropertyTaskAsync(propertyInfo);
                SetInformationText("Property", content);
            }
        }

        private async void UpdateConstructorInfoHandler(object sender, EventArgs e)
        {
            if (quickViewLoadObjects.TypesComboBox.Focused)
            {
                UpdateTypeInfoHandler(null, EventArgs.Empty);
                return;
            }

            var selectedCtor = quickViewLoadObjects.SelectedConstructor;

            if (selectedCtor != null)
            {
                string content = await InfoGathering.DescribeConstructorTaskAsync(selectedCtor);
                SetInformationText("Constructor", content);
            }
        }

        private void buttonDockFill_Click(object sender, EventArgs e)
        {
            TryToSetDockOfObj(DockStyle.Fill);
        }

        private void buttonDockNone_Click(object sender, EventArgs e)
        {
            TryToSetDockOfObj(DockStyle.None);
        }

        private void buttonShowFailsafe_Click(object sender, EventArgs e)
        {
            if (LoadedObject == null)
            {
                Program.ShowError(NO_OBJ_MSG);
                return;
            }

            Control control = LoadedObject as Control;

            if (control != null)
            {
                control.Show();
                control.Location = controlStartPos;
                control.Size = new Size(300, 300);
            }
            else
            {
                Type type = LoadedObject.GetType();
                MethodInfo showMethod = type.GetMethods().FirstOrDefault(m => m.Name == "Show");

                if (showMethod != null && showMethod.GetParameters().Length == 0)
                {
                    try
                    {
                        showMethod.Invoke(LoadedObject, null);
                        return;
                    }
                    catch (Exception ex)
                    {
                        ex.ShowErrorDialog();
                    }
                }

                PropertyInfo property = type.GetProperty("Visible");

                if (property != null && property.PropertyType == typeof(bool))
                {
                    property.SetValue(LoadedObject, true);
                }
            }
        }

        private void buttonUnload_Click(object sender, EventArgs e)
        {
            if (LoadedObject == null)
            {
                Program.ShowError(NO_OBJ_MSG);
                return;
            }

            quickViewProperties.SelectedObject = null;
            quickViewEvents.ClearEvents();
            quickViewMethods.ClearMethods();
            panelControlParent.Controls.Clear();
            IDisposable disposable = LoadedObject as IDisposable;
            disposable?.Dispose();
            panelControlParent.Invalidate();
            LoadedObject = null;
        }

        private void toolStripInfo_DoubleClick(object sender, EventArgs e)
        {
            infoPanelColapser.Toggle();
        }

        private void labelMoreInfoLink_Click(object sender, EventArgs e)
        {
            LookupSelectionOnWeb();
        }

        private void toolStripEvents_Click(object sender, EventArgs e)
        {
            eventPanelColapser.Toggle();
        }

        private void splitContainerRight_SplitterMoved(object sender, SplitterEventArgs e)
        {
            EventPanelColapserOnControlColapsedToggled(this, eventPanelColapser.IsColapsed);
        }
    }
}
