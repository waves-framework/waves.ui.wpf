using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Waves.UI.Windows.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseStringIsNullOrEmptyToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var o = value;
            return string.IsNullOrEmpty(o?.ToString()) ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}