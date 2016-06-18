using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;

namespace WinFormsSandbox.TypeConverters
{
    /// <summary>
    /// Converts a <see cref="Pen"/> type to and from an string type.
    /// </summary>
    [TargetType(typeof(Pen))]
    public class PenTypeConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param><param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to. </param>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Pen))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param><param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from. </param>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param><param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture. </param><param name="value">The <see cref="T:System.Object"/> to convert. </param><exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value != null)
            {
                var str = value.ToString();
                string[] splitted = str.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                Color color = Color.Empty;
                float stroke = 0;
                PenAlignment alignment = PenAlignment.Center;

                // Get color.
                if (splitted.Length >= 1)
                {
                    color = Color.FromName(splitted[0]);

                    if (color.R == 0 && color.G == 0 && color.B == 0 && color.A == 0)
                    {
                        string[] ARGB = splitted[0].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                        int[] numbers = ARGB.Select(int.Parse).ToArray();

                        if (ARGB.Length == 4)
                        {
                            color = Color.FromArgb(numbers[0], numbers[1], numbers[2], numbers[3]);
                        }
                        else if (ARGB.Length == 3)
                        {
                            color = Color.FromArgb(numbers[0], numbers[1], numbers[2]);
                        }
                    }

                    if (color.R == 0 && color.G == 0 && color.B == 0 && color.A == 0)
                    {
                        throw new FormatException("Invalid color format.");
                    }
                }

                if (splitted.Length >= 2)
                {
                    string strokeString = splitted[1].TrimEnd('f');

                    if (!float.TryParse(strokeString, out stroke))
                    {
                        throw new FormatException("Invalid stroke format.");
                    }
                }

                if (splitted.Length >= 3)
                {
                    alignment = (PenAlignment) Enum.Parse(typeof (PenAlignment), splitted[2]);
                }

                return new Pen(color, stroke) {Alignment = alignment};
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param><param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed. </param><param name="value">The <see cref="T:System.Object"/> to convert. </param><param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to. </param><exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null. </exception><exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            Pen pen = (Pen) value;
            KnownColor knownColor = pen.Color.ToKnownColor();
            string colorName = string.Empty;

            if (pen.Color.A != 255)
            {
                colorName += pen.Color.A + " ";
            }

            colorName += knownColor == 0 ? $@"{pen.Color.R} {pen.Color.G} {pen.Color.B}" : knownColor.ToString();
            return $@"{colorName}, {pen.Width}, {pen.Alignment}";
        }
    }
}
