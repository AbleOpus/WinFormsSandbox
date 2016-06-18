using System.Diagnostics;
using System.IO;

namespace WinFormsSandbox
{
    /// <summary>
    /// Describes an assembly file.
    /// </summary>
    public class AssemblyDescriptor
    {
        /// <summary>
        /// Get the name of the assembly.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the fully qualified path of the assembly.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Gets the version information of the assembly.
        /// </summary>
        public FileVersionInfo VersionInfo { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyDescriptor"/> class
        /// with the specified arguments.
        /// </summary>
        /// <param name="fullName">The fully qualified path of the assembly.</param>
        /// <param name="versionInfo">The version information of the assembly.</param>
        public AssemblyDescriptor(string fullName, FileVersionInfo versionInfo)
        {
            Name = Path.GetFileName(fullName);
            FullName = fullName;
            VersionInfo = versionInfo;
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
            return $"{Name} {VersionInfo.FileVersion}";
        }
    }
}