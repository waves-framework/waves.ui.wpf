using System;
using System.Globalization;
using System.Windows.Data;

namespace Waves.UI.Windows.Converters.Base
{
    /// <inheritdoc />
    public class ProgressValueToDegreeConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            var progress = 360.0d * (double) value / 100.0d;

            if (progress > 360) progress = 360;
            if (progress < 0) progress = 0;

            return progress;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}