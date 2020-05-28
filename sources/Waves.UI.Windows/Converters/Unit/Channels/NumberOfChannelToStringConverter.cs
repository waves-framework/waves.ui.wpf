using System;
using System.Globalization;
using System.Windows.Data;

namespace Waves.UI.Windows.Converters.Unit.Channels
{
    /// <inheritdoc />
    public class NumberOfChannelToStringConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = (short) value;
            var text = value + " канал";

            if (number >= 0 && number <= 100)
                if (number < 10 || number > 19)
                {
                    var rem = 0;

                    if (number < 10)
                        rem = number;
                    else
                        rem = number % 10;

                    if (rem == 0)
                        return text + "ов";
                    if (rem == 1)
                        return text;
                    if (rem == 2)
                        return text + "а";
                    if (rem == 3)
                        return text + "а";
                    if (rem == 4)
                        return text + "а";
                    if (rem == 5)
                        return text + "ов";
                    if (rem == 6)
                        return text + "ов";
                    if (rem == 7)
                        return text + "ов";
                    if (rem == 8)
                        return text + "ов";
                    if (rem == 9)
                        return text + "ов";
                }

            return text + "ов";
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}