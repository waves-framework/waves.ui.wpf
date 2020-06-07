using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Waves.UI.WPF.Converters.Base
{
    /// <summary>
    ///     Конвертер цвета в SolidColorBrush
    /// </summary>
    public class SolidColorBrushToSystemColorConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = (SolidColorBrush) value;
            return brush?.Color;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            var color = (Color) value;
            return new SolidColorBrush(color);
        }
    }
}