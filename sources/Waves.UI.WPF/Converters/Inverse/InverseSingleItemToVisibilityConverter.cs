using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Waves.UI.WPF.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseSingleItemToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (int) value == 1 ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}