using System;
using System.Reflection;
using System.Windows.Forms;
using WinFormsSandbox.Properties;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Groups assembly-loading-related controls into a colapsable parent.
    /// </summary>
    public partial class LoadAssemQuickView : QuickView
    {
        /// <summary>
        /// Occurs when the "load assemblies" <see cref="Button"/> has been clicked.
        /// </summary>
        public event EventHandler LoadAssembliesButtonClick
        {
            add { buttonLoadAssemblies.Click += value; }
            remove { buttonLoadAssemblies.Click -= value; }
        }

        /// <summary>
        /// Occurs when the "add probing path" <see cref="Button"/> has been clicked.
        /// </summary>
        public event EventHandler AddProblingPathButtonClick
        {
            add { buttonAddProbingPath.Click += value; }
            remove { buttonAddProbingPath.Click -= value; }
        }

        /// <summary>
        /// Occurs when an assembly has been loaded.
        /// </summary>
        public event EventHandler AssembliesLoaded;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadAssemQuickView"/> class.
        /// </summary>
        public LoadAssemQuickView()
        {
            InitializeComponent();
        }

        private void buttonFromGAC_Click(object sender, EventArgs e)
        {
            using (var dialogGacAssemblies = new GacAssembliesDialog())
            {
                if (dialogGacAssemblies.ShowDialog() == DialogResult.OK)
                {
                    foreach (var desc in dialogGacAssemblies.GetCheckedAssemblies())
                    {
                        try
                        {
                            Assembly.LoadFile(desc.FullName);
                        }
                        catch (BadImageFormatException ex)
                        {
                            ex.ShowErrorDialog();
                        }
                    }

                    if (dialogGacAssemblies.GetCheckedAssemblies().Length > 0)
                    {
                        AssembliesLoaded?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void buttonAddProbingPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialogFolderBrowser = new FolderBrowserDialog())
            {
                dialogFolderBrowser.SelectedPath = Settings.Default.LastProbingPath;
                dialogFolderBrowser.Description = "Select probing path";
                dialogFolderBrowser.ShowNewFolderButton = false;

                if (dialogFolderBrowser.ShowDialog() == DialogResult.OK)
                {
#pragma warning disable 618
                    AppDomain.CurrentDomain.AppendPrivatePath("file:///" +
                        dialogFolderBrowser.SelectedPath.Replace("\\", "/"));
#pragma warning restore 618

                    Settings.Default.LastProbingPath = dialogFolderBrowser.SelectedPath;
                }
            }
        }
    }
}
