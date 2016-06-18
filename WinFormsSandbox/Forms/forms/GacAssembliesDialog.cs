using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSandbox.Properties;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Presents assemblies in the GAC in a checkable <see cref="ListView"/> (to be loaded
    /// into the app domain).
    /// </summary>
    public partial class GacAssembliesDialog : DialogBox
    {
        private AssemblyDescriptor[] descriptors = {};

        /// <summary>
        /// Gets all of the assemblies that are checked in the <see cref="ListView"/>.
        /// </summary>
        public AssemblyDescriptor[] GetCheckedAssemblies()
        {
            return listView.CheckedItems.OfType<ListViewItem>().
           Select(item => (AssemblyDescriptor)item.Tag).ToArray();
        }

        /// <summary>
        /// Gets the GAC directory for the current system.
        /// Example: "C:\Windows\Assembly".
        /// </summary>
        private static string GacDirectory
        {
            get
            {
                string sysRoot = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                return Path.Combine(sysRoot, "Assembly");
            }
        }

        /// <summary>
        /// Gets the currently selected assembly.
        /// </summary>
        private AssemblyDescriptor SelectedAssembly
        {
            get
            {
                if (listView.SelectedItems.Count == 0)
                    return null;

                return (AssemblyDescriptor)listView.SelectedItems[0].Tag;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GacAssembliesDialog"/> class.
        /// </summary>
        public GacAssembliesDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Removes the comments at the end of the specified version information.
        /// </summary>
        private static string ProcessVersionInfo(string version)
        {
            if (String.IsNullOrWhiteSpace(version))
                return string.Empty;

            string[] split = version.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length == 0)
                return string.Empty;

            return split[0];
        }

        private void PopulateListView(IEnumerable<AssemblyDescriptor> descriptors)
        {
            listView.BeginUpdate();
            listView.Items.Clear();

            foreach (var desc in descriptors)
            {
                string fileName = desc.Name.CapFirstLetter();
                fileName = Path.GetFileNameWithoutExtension(fileName);

                if (fileName.EndsWith(".ni", true, CultureInfo.CurrentCulture))
                {
                    fileName = fileName.Remove(fileName.Length - 3, 3);
                }

                var parentItem = new ListViewItem(fileName);
                parentItem.Tag = desc; // Store the descriptors in the tag property.
                parentItem.SubItems.Add(ProcessVersionInfo(desc.VersionInfo.FileVersion));
                parentItem.SubItems.Add(desc.VersionInfo.FileDescription);
                listView.Items.Add(parentItem);
            }

            listView.EndUpdate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            labelStatus.Text = "Loading from GAC...";
            descriptors = await GetAssemblyDescritorsTaskAsync();
            labelStatus.Text = "Listing...";
            PopulateListView(descriptors);
            labelStatus.Text = "Idle";
            textBoxFilter.Focus();
        }

        /// <summary>
        /// Asynchronously retrieves the GAC assemblies and represents them as <see cref="AssemblyDescriptor"/> types.
        /// </summary>
        /// <returns></returns>
        private static Task<AssemblyDescriptor[]> GetAssemblyDescritorsTaskAsync()
        {
            return Task.Run(() =>
            {
                string[] paths;

                try
                {
                    paths = Directory.GetFiles(GacDirectory, "*.dll", SearchOption.AllDirectories);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Program.ShowError(ex.Message + "\n\nMake sure this program is run with administrative rights.");
                    return new AssemblyDescriptor[] {};
                }
                catch (IOException ex)
                {
                    ex.ShowErrorDialog();
                    return new AssemblyDescriptor[] { };
                }

                return paths.Select(p => new AssemblyDescriptor(p, FileVersionInfo.GetVersionInfo(p))).ToArray();
            });
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedAssembly != null)
            {
                textBoxLocation.Text = SelectedAssembly.FullName;
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
           string filter = textBoxFilter.Text.ToLower();
            PopulateListView(descriptors.Where(d => d.Name.Contains(filter)));
        }

        private void buttonExploreGac_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GacDirectory);
            }
            catch (Exception ex)
            {
                ex.ShowErrorDialog();
            }
        }
    }
}
