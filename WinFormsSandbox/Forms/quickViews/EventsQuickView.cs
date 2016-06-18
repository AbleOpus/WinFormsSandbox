using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Groups event-related controls into a colapsable parent.
    /// </summary>
    public partial class EventsQuickView : QuickView
    {

        /// <summary>
        /// Gets the events that are checked in the events <see cref="CheckedListBox"/>.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventInfo[] CheckedEvents =>
            checkedListEvents.CheckedItems.OfType<EventInfoCheckedListItem>().Select(t => t.EventInfo).ToArray();

        /// <summary>
        /// Gets the currently selected event.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventInfo SelectedEvent => ((EventInfoCheckedListItem)checkedListEvents.SelectedItem)?.EventInfo;

        /// <summary>
        /// Occurs when the selected event has changed.
        /// </summary>
        public event EventHandler SelectedEventChanged
        {
            add { checkedListEvents.SelectedIndexChanged += value; }
            remove { checkedListEvents.SelectedIndexChanged -= value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsQuickView"/> class.
        /// </summary>
        public EventsQuickView()
        {
            InitializeComponent();
            checkedListEvents.SelectedIndexChanged += CheckedListEvents_SelectedIndexChanged; 
        }

        /// <summary>
        /// Populates the <see cref="CheckedListBox"/> with the specified events.
        /// </summary>
        /// <param name="eventInfos">The events to add.</param>
        public void PopulateEvents(EventInfo[] eventInfos)
        {
            var items = eventInfos.Select(t => new EventInfoCheckedListItem(t));

            checkedListEvents.Items.Clear();

            foreach (var item in items)
            {
                checkedListEvents.Items.Add(item);
            }
        }

        /// <summary>
        /// Clears all event items.
        /// </summary>
        public void ClearEvents()
        {
            checkedListEvents.Items.Clear();
        }

        /// <summary>
        /// Checks all events in the <see cref="CheckedListBox"/>.
        /// </summary>
        public void CheckAllEvents()
        {
            for (int i = 0; i < checkedListEvents.Items.Count; i++)
                checkedListEvents.SetItemChecked(i, true);
        }

        private void CheckedListEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var attrib = SelectedEvent?.GetCustomAttribute<DescriptionAttribute>();

            if (attrib != null)
            {
                labelDescription.Text = attrib.Description;
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            CheckAllEvents();
        }

        private void buttonNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListEvents.Items.Count; i++)
                checkedListEvents.SetItemChecked(i, false);
        }
    }
}
