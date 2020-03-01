﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters
{
    /// <inheritdoc />
    public class IconStringKeyToGeometryConverter : IValueConverter
    {
        /// <summary>
        /// Новый экземпляр конвертера
        /// </summary>
        public IconStringKeyToGeometryConverter()
        {
            Dictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/Fluid.UI;component/Resources/Icons.xaml")
            };
        }

        /// <summary>
        /// Словарь ресурсов иконок.
        /// </summary>
        public ResourceDictionary Dictionary { get; }

        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = (string) value;
            return key == null ? null : Dictionary[key];
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}