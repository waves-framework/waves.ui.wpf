using System;
using System.Globalization;
using System.Windows.Data;

namespace Waves.UI.Windows.Converters.Unit.Voltage
{
    /// <inheritdoc />
    public class VoltsToStringConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var v = System.Convert.ToSingle(value);
                var i = (int) Math.Log10(v);

                if (v >= 1)
                {
                    if (i > 0 && i < 3)
                        return Math.Round(v, 2) + " В";
                }
                else
                {
                    if (i > -3 && i <= 0)
                        return Math.Round(v * 1000, 2) + " мВ";
                    if (i > -6 && i <= -3)
                        return Math.Round(v * 100000, 2) + " мкВ";
                }
            }
            catch (Exception)
            {
                return value + " В";
            }

            return value + " В";
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}