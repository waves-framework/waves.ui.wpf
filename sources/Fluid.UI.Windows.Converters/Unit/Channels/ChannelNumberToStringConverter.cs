using System;
using System.Globalization;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Unit.Channels
{
    /// <inheritdoc />
    public class ChannelNumberToStringConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = System.Convert.ToInt16(value);
            return "Канал " + (number + 1);
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
