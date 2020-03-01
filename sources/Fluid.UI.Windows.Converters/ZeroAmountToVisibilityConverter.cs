using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters
{
    /// <inheritdoc />
    public class InverseZeroAmountToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (int)value == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}