using System;
using System.Globalization;
using System.Windows.Data;

namespace Waves.UI.Windows.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseZeroAmountToBoolConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null || (int) value != 0;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}