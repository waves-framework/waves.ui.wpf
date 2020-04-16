using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !(bool) value)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (Visibility) value != Visibility.Visible;
        }
    }
}