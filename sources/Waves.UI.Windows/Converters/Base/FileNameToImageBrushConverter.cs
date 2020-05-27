using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Waves.UI.Windows.Converters.Base
{
    /// <inheritdoc />
    public class FileNameToImageBrushConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileName = (string) value;

            if (string.IsNullOrEmpty(fileName)) return null;
            if (!File.Exists(fileName)) return null;

            var stretchString = parameter as string;
            var stretch = Stretch.None;

            if (stretchString != null)
            {
                if (stretchString == "None")
                    stretch = Stretch.None;
                else if (stretchString == "Fill")
                    stretch = Stretch.Fill;
                else if (stretchString == "Uniform")
                    stretch = Stretch.Uniform;
                else if (stretchString == "UniformToFill")
                    stretch = Stretch.UniformToFill;
            }

            var image = new BitmapImage(new Uri(fileName, UriKind.Relative));
            return new ImageBrush(image) {Stretch = stretch};
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}