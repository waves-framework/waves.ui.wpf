using System;
using System.Globalization;
using System.Windows.Data;
using Fluid.Core.Base;

namespace Fluid.UI.Windows.Converters
{
    /// <inheritdoc />
    public class FluidColorToHexStringConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color?) value;
            return color?.ToHexString();
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = (string) value;
            var parse = Color.TryParseFromHex(text, out var color, out var hasAlpha);
            return parse ? (object) color : null;
        }
    }
}