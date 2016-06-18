using System.CodeDom.Compiler;

namespace WinFormsSandbox
{
    /// <summary>
    /// Represents the results yielded from a custom code execution operation.
    /// </summary>
    public class CustomCodeExecutionResults
    {
        /// <summary>
        /// Gets any errors that occurred during compilation.
        /// </summary>
        public CompilerErrorCollection Errors { get; }

        /// <summary>
        /// Gets the line index where the custom code starts. Use this to figure out where
        /// errors are in the custom code itself.
        /// </summary>
        public int CustomCodeOffset { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCodeExecutionResults"/> with 
        /// the specified arguments.
        /// </summary>
        /// <param name="errors">Any errors that occurred during compilation.</param>
        /// <param name="customCodeOffset">The line index where the custom code starts.</param>
        public CustomCodeExecutionResults(CompilerErrorCollection errors, int customCodeOffset)
        {
            Errors = errors;
            CustomCodeOffset = customCodeOffset;
        }
    }
}
