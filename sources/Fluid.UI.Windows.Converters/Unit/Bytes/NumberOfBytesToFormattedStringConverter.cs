using System;
using System.Globalization;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Unit.Bytes
{
    /// <inheritdoc />
    public class NumberOfBytesToFormattedStringConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = string.Empty;
            if (value == null) return text;

            var count = (long) value;

            if (count == 0)
                text += "0 байт";
            if (count > 0 && count <= 1048576)
                text += Math.Round(count / 1024.0f, 2) + " Кб";
            if (count > 1048576 && count <= 1073741824)
                text += Math.Round(count / 1048576.0f, 2) + " Мб";
            if (count > 1073741824)
                text += Math.Round(count / 1073741824.0f, 2) + " Гб";

            return text;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}