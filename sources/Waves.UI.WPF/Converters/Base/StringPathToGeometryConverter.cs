using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Waves.UI.WPF.Converters.Base
{
    /// <inheritdoc />
    public class StringPathToGeometryConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string) value;
            return string.IsNullOrEmpty(path) ? null : Geometry.Parse(path);
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}