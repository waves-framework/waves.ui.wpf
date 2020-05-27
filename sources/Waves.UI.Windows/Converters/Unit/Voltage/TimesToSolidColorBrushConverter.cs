using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Waves.UI.Windows.Converters.Unit.Voltage
{
    /// <inheritdoc />
    public class TimesToSolidColorBrushConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = (double) value;

            if (v < 0) v = 0;
            if (v > 1) v = 1;

            var r = (byte) (240 * Heaviside(v, 0.7f) - 55 * Heaviside(v, 0.9f));
            var g = (byte) (167 + 10 * Heaviside(v, 0.7f) - 165 * Heaviside(v, 0.9f));
            var b = (byte) (120 - 50 * Heaviside(v, 0.7f) - 65 * Heaviside(v, 0.9f));

            return new SolidColorBrush(Color.FromArgb(255, r, g, b));
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        /// <summary>
        ///     Вычисление функции Хевисайда.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Heaviside(double a, double b)
        {
            return 0.5f + 0.5f * (a - b) / Math.Sqrt((a - b) * (a - b) + 0.0001);
        }
    }
}