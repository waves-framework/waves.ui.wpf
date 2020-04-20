using System;
using System.Globalization;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Unit.Hertz
{
    /// <inheritdoc />
    public class HertzToShortStringConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var v = System.Convert.ToDouble(value);
                var i = (int) Math.Log10(v);

                if (v >= 1)
                {
                    if (i >= 1 && i < 3)
                        return Math.Round(v, 2) + " Гц";
                    if (i >= 3 && i < 6)
                        return Math.Round(v / 1000, 2) + " кГц";
                    if (i >= 6 && i < 9)
                        return Math.Round(v / 1000000, 2) + " МГц";
                    if (i >= 9 && i < 12)
                        return Math.Round(v / 1000000000, 2) + " ГГц";
                }
                else
                {
                    // TODO: Сделать значения меньше 1
                    return value + " Гц";
                }
            }
            catch (Exception)
            {
                return value;
            }

            return value;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}