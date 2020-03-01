using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseNullToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
