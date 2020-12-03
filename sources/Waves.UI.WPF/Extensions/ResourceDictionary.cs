using System.Collections.Generic;
using System.Windows.Media;
using Waves.Core.Base;

namespace Waves.UI.WPF.Extensions
{
    /// <summary>
    /// Resource dictionary extensions.
    /// </summary>
    public static class ResourceDictionary
    {
        /// <summary>
        ///     Gets colors dictionary from resource dictionary.
        /// </summary>
        /// <param name="dictionary">Resource dictionary.</param>
        /// <param name="key">Key.</param>
        /// <param name="weights">Weight.</param>
        /// <returns>Colors dictionary.</returns>
        public static Dictionary<int, WavesColor> GetColorsDictionary(this System.Windows.ResourceDictionary dictionary, string key,
            int[] weights)
        {
            var result = new Dictionary<int, WavesColor>();

            foreach (var weight in weights)
                result.Add(weight, GetColorFromResourceDictionary(dictionary, key, weight));

            return result;
        }

        /// <summary>
        ///     Gets color from resource dictionary by key and weight.
        /// </summary>
        /// <param name="dictionary">Resource dictionary.</param>
        /// <param name="key">Key.</param>
        /// <param name="weight">Weight.</param>
        /// <returns>Color.</returns>
        public static WavesColor GetColorFromResourceDictionary(this System.Windows.ResourceDictionary dictionary, string key, int weight)
        {
            var currentKey = key + "-" + weight;

            var color = (System.Windows.Media.Color)dictionary[currentKey];

            return color.ToWavesColor();
        }

        /// <summary>
        ///     Gets colors dictionary from resource dictionary.
        /// </summary>
        /// <param name="dictionary">ResourceDictionary</param>
        /// <returns>Colors dictionary.</returns>
        public static Dictionary<string, WavesColor> GetColorsDictionary(System.Windows.ResourceDictionary dictionary)
        {
            var result = new Dictionary<string, WavesColor>();

            foreach (var key in dictionary.Keys)
            {
                var str = key.ToString();
                if (str.EndsWith("-Color") && !str.EndsWith("-Foreground-Color"))
                {
                    var color = (System.Windows.Media.Color)dictionary[str];
                    result.Add(str, color.ToWavesColor());
                }
            }

            return result;
        }

        /// <summary>
        ///     Gets foreground colors dictionary from resource dictionary.
        /// </summary>
        /// <param name="dictionary">ResourceDictionary</param>
        /// <returns>Colors dictionary.</returns>
        public static Dictionary<string, WavesColor> GetForegroundColorsDictionary(System.Windows.ResourceDictionary dictionary)
        {
            var result = new Dictionary<string, WavesColor>();

            foreach (var key in dictionary.Keys)
            {
                var str = key.ToString();
                if (str.EndsWith("-Foreground-Color"))
                {
                    var color = (System.Windows.Media.Color)dictionary[str];
                    result.Add(str, color.ToWavesColor());
                }
            }

            return result;
        }
    }
}