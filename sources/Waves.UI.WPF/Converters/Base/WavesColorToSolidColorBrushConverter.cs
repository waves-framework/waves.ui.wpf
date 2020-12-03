using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Waves.Core.Base;

namespace Waves.UI.WPF.Converters.Base
{
    /// <inheritdoc />
    public class WavesColorToSolidColorBrushConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) 
                return new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            var color = (WavesColor) value;
            return new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}