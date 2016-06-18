using System.Reflection;
using System.Windows.Forms;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents an event-related item for an <see cref="CheckedListBox"/>.
    /// </summary>
    public class EventInfoCheckedListItem
    {
        /// <summary>
        /// Gets the event info.
        /// </summary>
        public EventInfo EventInfo { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventInfoCheckedListItem"/> class
        /// with the specified argument.
        /// </summary>
        /// <param name="eventInfo">The event info.</param>
        public EventInfoCheckedListItem(EventInfo eventInfo)
        {
            EventInfo = eventInfo;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return EventInfo.Name;
        }
    }
}
