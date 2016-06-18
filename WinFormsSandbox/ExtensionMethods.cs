using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WinFormsSandbox
{
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Capitalizes the first letter in the specified string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>The specified string with its first letter capitalized.</returns>
        public static string CapFirstLetter(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return string.Empty;

            if (str.Length == 1)
                return str.ToUpper();

            char firstLetter = str[0];
            return char.ToUpper(firstLetter) + str.Substring(1, str.Length -1);
        }

        /// <summary>
        /// Indents the specified string by the specified amount of spaces. The line-break type
        /// can be manually specified or inferred.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="spaces">How many spaces to insert before each line.</param>
        /// <param name="mode">The line break type of the string.</param>
        /// <returns>The modified string.</returns>
        public static string Indent(this string str, int spaces = 4, LineBreakKind mode = LineBreakKind.Auto)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            // Get what is used as a line separator.
            string seperator;

            switch (mode)
            {
                case LineBreakKind.Auto:
                    seperator = str.IndexOf("\r\n") != -1 ? "\r\n" : "\n";
                    break;

                    case LineBreakKind.LegacyNewLine:
                    seperator = "\r\n";
                    break;

                case LineBreakKind.NewLine:
                    seperator = "\n";
                    break;

                default:
                    throw new InvalidEnumArgumentException(nameof(mode), (int)mode, mode.GetType());
            }

            // Create space string.
            string spaceString = string.Empty;

            for (int i = 0; i < spaces; i++)
                spaceString += ' ';

            string[] splitted = str.Split(new[] { seperator }, StringSplitOptions.None);

            for (int i = 0; i < splitted.Length; i++)
            {
                splitted[i] = spaceString + splitted[i];
            }

            StringBuilder SB = new StringBuilder();

            for (int i = 0; i < splitted.Length; i++)
            {
                SB.Append(spaceString + splitted[i]);

                if (i != splitted.Length - 1)
                    SB.Append(spaceString).Append(seperator);
            }

            return SB.ToString();
        }

        /// <summary>
        /// Creates a universal event handler dynamically.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="e"></param>
        /// <param name="action">The base event handler.</param>
        /// <returns>The delegate for the specified Action.</returns>
        public static Delegate CreateHandler<T1, T2>(this EventInfo e, Action<T1, T2> action)
        {
            var parameters = e.EventHandlerType.GetMethod("Invoke").GetParameters().Select(p =>
            Expression.Parameter(p.ParameterType, "p")).ToArray();
            var exp = Expression.Call(Expression.Constant(action), action.GetType().GetMethod("Invoke"), parameters);
            var l = Expression.Lambda(exp, parameters);
            return Delegate.CreateDelegate(e.EventHandlerType, l.Compile(), "Invoke", false);
        }

        /// <summary>
        /// Gets the local file path of the assembly.
        /// </summary>
        public static string GetLocalFilePath(this Assembly assembly)
        {
            string fileName = assembly.CodeBase;

            if (fileName.StartsWith("file:///"))
            {
                fileName = fileName.Remove(0, 8);
            }

            return fileName.Replace('/', '\\');
        }

        /// <summary>
        /// Gets the parent directory of the assembly.
        /// </summary>
        public static string GetLocalParentDirectory(this Assembly assembly)
        {
            return Path.GetDirectoryName(assembly.GetLocalFilePath());
        }

        /// <summary>
        /// Appends the specified number of spaces. By default, the space count is 4.
        /// This is the typical representation of tabs in code editors (code editors do
        /// not use tab characters).
        /// </summary>
        /// <param name="SB"></param>
        /// <param name="spaces">How many spaces to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public static StringBuilder Indent(this StringBuilder SB, int spaces = 4)
        {
            for (int i = 0; i < spaces; i++)
                SB.Append(" ");

            return SB;
        }

        // Summary:
        //     Determines whether this string and a specified System.String object have the
        //     same value. A parameter specifies the culture, case, and sort rules used in the
        //     comparison.
        //
        // Parameters:
        //   value:
        //     The string to compare to this instance.
        //
        //   comparisonType:
        //     One of the enumeration values that specifies how the strings will be compared.
        //
        // Returns:
        //     true if the value of the value parameter is the same as this string; otherwise,
        //     false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     comparisonType is not a System.StringComparison value.

        /// <summary>
        /// Determines whether this string and a specified System.String object have the
        /// same value. A parameter specifies the culture, case, and sort rules used in the
        /// comparison.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strs">The strings to compare to this instance.</param>
        /// <param name="options">One of the enumeration values that specifies how the strings will be compared.</param>
        /// <returns>True if this instance matches any of the specified strings, otherwise false.</returns>
        /// <exception cref="ArgumentException">Options is not a valid <see cref="StringComparison"/> value.</exception>
        public static bool EqualsAny(this string str, IEnumerable<string> strs, 
            StringComparison options = StringComparison.OrdinalIgnoreCase)
        {
            return strs.Any(s => s.Equals(str, options));
        }

        /// <summary>
        /// Shows the <see cref="Exception"/>'s message in a message dialog.
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowErrorDialog(this Exception ex)
        {
            Debugger.Break();

            MessageBox.Show(ex.Message, Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Scrolls the <see cref="DataGridView"/> all the way down.
        /// </summary>
        public static void ScrollToBottom(this DataGridView view)
        {
            view.FirstDisplayedScrollingRowIndex = view.RowCount - 1;
        }

        /// <summary>
        /// Gets whether the Type is static.
        /// </summary>
        public static bool IsStatic(this Type type)
        {
            return type.IsAbstract && type.IsSealed;
        }

        /// <summary>
        /// Gets whether the string starts with any of the specified strings.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strs">The potential prefixes.</param>
        /// <returns>True, if the string starts with one of the test strings, otherwise false.</returns>
        public static bool StartsWithAny(this string str, params string[] strs)
        {
            return strs.Any(str.StartsWith);
        }

        /// <summary>
        /// Changes the brightness of a color by altering its RGB values.
        /// </summary>
        /// <param name="color">The color to be altered.</param>
        /// <param name="factor">The amount to change and in what way (Negative is darker).</param>
        /// <returns>Color that has been altered.</returns>
        public static Color ChangeBrightness(this Color color, int factor)
        {
            int R = (color.R + factor > 255) ? 255 : color.R + factor;
            int G = (color.G + factor > 255) ? 255 : color.G + factor;
            int B = (color.B + factor > 255) ? 255 : color.B + factor;
            if (R < 0) R = 0;
            if (B < 0) B = 0;
            if (G < 0) G = 0;
            return Color.FromArgb(R, G, B);
        }
    }
}
