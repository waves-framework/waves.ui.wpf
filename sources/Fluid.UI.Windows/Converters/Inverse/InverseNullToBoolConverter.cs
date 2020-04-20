using System;
using System.Globalization;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Inverse
{
    /// <inheritdoc />
    public class InverseNullToBoolConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}