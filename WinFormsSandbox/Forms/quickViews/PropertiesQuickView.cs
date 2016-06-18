using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Groups property-related controls into a colapsable parent.
    /// </summary>
    public partial class PropertiesQuickView : QuickView
    {
        /// <summary>
        /// Gets or sets the object loaded into the <see cref="PropertyGrid"/> of this control.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedObject
        {
            get { return propertyGrid.SelectedObject; }
            set { propertyGrid.SelectedObject = value; }
        }

        /// <summary>
        /// Gets the currently selected property.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PropertyInfo SelectedProperty
        {
            get
            {
                var descriptor = propertyGrid.SelectedGridItem.PropertyDescriptor;
                return descriptor?.ComponentType.GetProperty(descriptor.Name);
            }
        }

        /// <summary>
        /// Occurs when the selected grid item (property) has changed.
        /// </summary>
        public event SelectedGridItemChangedEventHandler SelectedGridItemChanged
        {
            add { propertyGrid.SelectedGridItemChanged += value; }
            remove { propertyGrid.SelectedGridItemChanged -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesQuickView"/> class.
        /// </summary>
        public PropertiesQuickView()
        {
            InitializeComponent();
        }

        private void menuItemReset_Click(object sender, EventArgs e)
        {
            propertyGrid.ResetSelectedProperty();
        }

        private void contextPropGrid_Opening(object sender, CancelEventArgs e)
        {
            if (propertyGrid.SelectedGridItem.GridItemType == GridItemType.Category ||
                propertyGrid.SelectedGridItem == null)
            {
                e.Cancel = true;
            }
        }
    }
}
