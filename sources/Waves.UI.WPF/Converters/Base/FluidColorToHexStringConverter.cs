using System;
using System.Globalization;
using System.Windows.Data;
using Waves.Core.Base;

namespace Waves.UI.WPF.Converters.Base
{
    /// <inheritdoc />
    public class WavesColorToHexStringConverter : IValueConverter
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