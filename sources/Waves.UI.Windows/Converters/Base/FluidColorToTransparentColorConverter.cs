using System;
using System.Globalization;
using System.Windows.Data;
using Waves.Core.Base;

namespace Waves.UI.Windows.Converters.Base
{
    public class WavesColorToTransparentColorConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var color = (Color) value;
                var newColor = new System.Windows.Media.Color
                {
                    A = 0,
                    R = color.R,
                    G = color.G,
                    B = color.B
                };
                return newColor;
            }

            return null;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}