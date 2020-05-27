using System;
using System.Globalization;
using System.Windows.Data;

namespace Waves.UI.Windows.Converters.Base
{
    /// <inheritdoc />
    public class ObjectToTypeNameConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return Extensions.Type.GetFriendlyName(value.GetType());

            return "Unknown";
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}