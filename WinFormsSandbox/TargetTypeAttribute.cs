using System;
using System.Text;
using WinFormsSandbox.TypeConverters;

namespace WinFormsSandbox
{
    /// <summary>
    /// Indicates that a class corresponds to a specific Type.
    /// For instance, the <see cref="StringBuilderTypeConverter"/> corresponds
    /// to a <see cref="StringBuilder"/>, therefore the <see cref="StringBuilderTypeConverter"/>
    /// should be marked with the <see cref="StringBuilder"/> type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    sealed class TargetTypeAttribute : Attribute
    {
        /// <summary>
        /// Gets the corresponding <see cref="Type"/>.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Type"/> class with
        /// the specified argument.
        /// </summary>
        /// <param name="type">The corresponding <see cref="Type"/>.</param>
        public TargetTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
