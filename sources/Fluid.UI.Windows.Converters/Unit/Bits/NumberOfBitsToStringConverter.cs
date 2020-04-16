using System;
using System.Globalization;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Unit.Bits
{
    /// <inheritdoc />
    public class NumberOfBitsToStringConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var number = (short) value;
                var text = value + " бит";

                if (number == 8)
                    return text;
                if (number == 12)
                    return text;
                if (number == 16)
                    return text;
                if (number == 24)
                    return text + "а";
                if (number == 32)
                    return text + "а";

                return text;
            }

            return string.Empty;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}