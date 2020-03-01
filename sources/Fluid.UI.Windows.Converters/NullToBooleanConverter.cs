﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters
{
    /// <inheritdoc />
    public class NullToBooleanConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
