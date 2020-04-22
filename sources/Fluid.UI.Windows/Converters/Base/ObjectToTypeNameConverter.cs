using System;
using System.Globalization;
using System.Windows.Data;

namespace Fluid.UI.Windows.Converters.Base
{
    /// <inheritdoc />
    public class ObjectToTypeNameConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null) return GetFriendlyName(value.GetType());

            return "Unknown";
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        /// <summary>
        ///     Gets friendly name of type (including generics).
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>Friendly name.</returns>
        public static string GetFriendlyName(Type type)
        {
            var friendlyName = type.Name;
            if (!type.IsGenericType) return friendlyName;

            var iBacktick = friendlyName.IndexOf('`');
            if (iBacktick > 0) friendlyName = friendlyName.Remove(iBacktick);
            friendlyName += "<";
            var typeParameters = type.GetGenericArguments();
            for (var i = 0; i < typeParameters.Length; ++i)
            {
                var typeParamName = GetFriendlyName(typeParameters[i]);
                friendlyName += i == 0 ? typeParamName : "," + typeParamName;
            }

            friendlyName += ">";

            return friendlyName;
        }
    }
}