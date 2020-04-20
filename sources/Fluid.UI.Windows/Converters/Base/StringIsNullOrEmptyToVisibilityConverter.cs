using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Base
{
    /// <inheritdoc />
    public class StringIsNullOrEmptyToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var o = value;
            return string.IsNullOrEmpty(o?.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}