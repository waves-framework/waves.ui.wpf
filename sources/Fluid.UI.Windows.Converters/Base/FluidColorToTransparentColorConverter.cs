using System;
using System.Globalization;
using System.Windows.Data;
using Fluid.Core.Base;

namespace Fluid.UI.Windows.Converters.Base
{
    public class FluidColorToTransparentColorConverter : IValueConverter
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