using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Waves.UI.Windows.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseZeroAmountToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (int) value == 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}