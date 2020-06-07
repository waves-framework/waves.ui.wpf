using System;
using System.Globalization;
using System.Windows.Data;

namespace Waves.UI.WPF.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseStringIsNullOrEmptyToBoolConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = (string) value;
            return !string.IsNullOrEmpty(s);
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}