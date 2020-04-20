using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Fluid.Core.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Color = Fluid.Core.Base.Color;

namespace Fluid.UI.Windows.Base
{
    /// <summary>
    ///     Theme.
    /// </summary>
    public class Theme : ObservableObject, ITheme
    {
        private const string PrimaryColorKey = "Color";
        private const string PrimaryForegroundColorKey = "Color-Foreground";
        private const string AccentColorKey = "Accent-Color";
        private const string AccentForegroundColorKey = "Accent-Color-Foreground";
        private readonly int[] _accentColorWeights = {100, 200, 300, 400, 500, 600, 700, 800, 900};
        private readonly int[] _accentForegroundColorWeights = {100, 500, 900};

        private readonly int[] _primaryColorWeights = {100, 200, 300, 400, 500, 600, 700, 800, 900};
        private readonly int[] _primaryForegroundColorWeights = {100, 500, 900};
        private Dictionary<int, Color> _accentColorDictionary;
        private ResourceDictionary _accentColorResourceDictionary;
        private Dictionary<int, Color> _accentForegroundColorDictionary;
        private Dictionary<string, Color> _miscellaneousColorDictionary;
        private ResourceDictionary _miscellaneousResourceDictionary;

        private Dictionary<int, Color> _primaryColorDictionary;

        private ResourceDictionary _primaryColorResourceDictionary;
        private Dictionary<int, Color> _primaryForegroundColorDictionary;

        /// <summary>
        ///     Creates new instance of <see cref="Theme" />
        /// </summary>
        /// <param name="name">Theme name.</param>
        /// <param name="id">Guid.</param>
        /// <param name="primary">Sets dictionary of primary colors.</param>
        /// <param name="accent">Sets dictionary of accent colors.</param>
        /// <param name="miscellaneous">Sets dictionary of miscellaneous colors.</param>
        /// <param name="isDark">Sets whether theme is dark.</param>
        public Theme(string name, Guid id, ResourceDictionary primary, ResourceDictionary accent,
            ResourceDictionary miscellaneous, bool isDark)
        {
            Name = name;
            Id = id;

            PrimaryColorResourceDictionary = primary;
            AccentColorResourceDictionary = accent;
            MiscellaneousResourceDictionary = miscellaneous;

            IsDark = isDark;

            InitializeColors();
        }

        /// <inheritdoc />
        public bool IsDark { get; }

        /// <inheritdoc />
        public Guid Id { get; }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public Color PrimaryExampleColor => GetPrimaryColor(100);

        /// <inheritdoc />
        public Color AccentExampleColor => GetAccentColor(500);

        /// <inheritdoc />
        public ResourceDictionary PrimaryColorResourceDictionary
        {
            get => _primaryColorResourceDictionary;
            set
            {
                if (value == _primaryColorResourceDictionary) return;
                _primaryColorResourceDictionary = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public ResourceDictionary AccentColorResourceDictionary
        {
            get => _accentColorResourceDictionary;
            set
            {
                if (value == _accentColorResourceDictionary) return;
                _accentColorResourceDictionary = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public ResourceDictionary MiscellaneousResourceDictionary
        {
            get => _miscellaneousResourceDictionary;
            set
            {
                if (value == _miscellaneousResourceDictionary) return;
                _miscellaneousResourceDictionary = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public Color GetPrimaryColor(int weight)
        {
            return _primaryColorDictionary[weight];
        }

        /// <inheritdoc />
        public Color GetPrimaryForegroundColor(int weight)
        {
            return _primaryForegroundColorDictionary[weight];
        }

        /// <inheritdoc />
        public Color GetAccentColor(int weight)
        {
            return _accentColorDictionary[weight];
        }

        /// <inheritdoc />
        public Color GetAccentForegroundColor(int weight)
        {
            return _accentForegroundColorDictionary[weight];
        }

        /// <inheritdoc />
        public Color GetMiscellaneousColor(string key)
        {
            return _miscellaneousColorDictionary[key];
        }

        /// <summary>
        ///     Initializes colors.
        /// </summary>
        private void InitializeColors()
        {
            _primaryColorDictionary =
                GetColorsDictionary(PrimaryColorResourceDictionary, PrimaryColorKey, _primaryColorWeights);
            _primaryForegroundColorDictionary = GetColorsDictionary(PrimaryColorResourceDictionary,
                PrimaryForegroundColorKey,
                _primaryForegroundColorWeights);
            _accentColorDictionary =
                GetColorsDictionary(AccentColorResourceDictionary, AccentColorKey, _accentColorWeights);
            _accentForegroundColorDictionary = GetColorsDictionary(AccentColorResourceDictionary,
                AccentForegroundColorKey, _accentForegroundColorWeights);
            _miscellaneousColorDictionary = GetColorsDictionary(MiscellaneousResourceDictionary);
        }

        /// <summary>
        ///     Gets colors dictionary from resource dictionary.
        /// </summary>
        /// <param name="dictionary">Resource dictionary.</param>
        /// <param name="key">Key.</param>
        /// <param name="weights">Weight.</param>
        /// <returns>Colors dictionary.</returns>
        private static Dictionary<int, Color> GetColorsDictionary(ResourceDictionary dictionary, string key,
            int[] weights)
        {
            var result = new Dictionary<int, Color>();

            foreach (var weight in weights)
                result.Add(weight, GetColorFromResourceDictionary(dictionary, key, weight));

            return result;
        }

        /// <summary>
        ///     Gets colors dictionary from resource dictionary.
        /// </summary>
        /// <param name="dictionary">ResourceDictionary</param>
        /// <returns>Colors dictionary.</returns>
        private static Dictionary<string, Color> GetColorsDictionary(ResourceDictionary dictionary)
        {
            var result = new Dictionary<string, Color>();

            foreach (var key in dictionary.Keys)
            {
                var str = key.ToString();
                if (str.EndsWith("-Brush"))
                {
                    var brush = (SolidColorBrush) dictionary[str];
                    result.Add(str, Extensions.Color.ToFluidColor(brush.Color));
                }
            }

            return result;
        }

        /// <summary>
        ///     Gets color from resource dictionary by key and weight.
        /// </summary>
        /// <param name="dictionary">Resource dictionary.</param>
        /// <param name="key">Key.</param>
        /// <param name="weight">Weight.</param>
        /// <returns>Color.</returns>
        private static Color GetColorFromResourceDictionary(ResourceDictionary dictionary, string key, int weight)
        {
            var currentKey = key + "-" + weight;
            var color = (System.Windows.Media.Color) dictionary[currentKey];
            return Extensions.Color.ToFluidColor(color);
        }
    }
}