using System;
using System.Collections.Generic;
using System.Windows;
using Fluid.Core.Base;
using Fluid.UI.Windows.Services.Interfaces;

namespace Fluid.UI.Windows.Services
{
    /// <summary>
    /// Класс представления темы.
    /// </summary>
    public class Theme : ObservableObject, ITheme
    {
        private const string PrimaryColorKey = "Color";
        private const string PrimaryForegroundColorKey = "Color-Foreground";
        private const string AccentColorKey = "Accent-Color";
        private const string AccentForegroundColorKey = "Accent-Color-Foreground";

        private readonly int[] _primaryColorWeights = { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
        private readonly int[] _primaryForegroundColorWeights = { 100, 500, 900 };
        private readonly int[] _accentColorWeights = { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
        private readonly int[] _accentForegroundColorWeights = { 100, 500, 900 };

        private Dictionary<int, Color> _primaryColorDictionary;
        private Dictionary<int, Color> _accentColorDictionary;
        private Dictionary<string, Color> _miscellaneousColorDictionary;
        private Dictionary<int, Color> _primaryForegroundColorDictionary;
        private Dictionary<int, Color> _accentForegroundColorDictionary;

        private ResourceDictionary _primaryColorResourceDictionary;
        private ResourceDictionary _accentColorResourceDictionary;
        private ResourceDictionary _miscellaneousResourceDictionary;

        /// <summary>
        /// Новый экземпляр темы.
        /// </summary>
        /// <param name="name">Наименование темы.</param>
        /// <param name="id">Theme's id.</param>
        /// <param name="primary">Словарь ресурсов основных цветов.</param>
        /// <param name="accent">Словарь ресурсов акцентных цветов.</param>
        /// <param name="miscellaneous">Словарь ресурсов дополнительных цветов.</param>
        public Theme(string name, Guid id, ResourceDictionary primary, ResourceDictionary accent, ResourceDictionary miscellaneous)
        {
            Name = name;
            Id = id;

            PrimaryColorResourceDictionary = primary;
            AccentColorResourceDictionary = accent;
            MiscellaneousResourceDictionary = miscellaneous;

            InitializeColors();
        }

        /// <inheritdoc />
        public Guid Id { get; private set; }

        /// <inheritdoc />
        public string Name { get; private set; }

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
        /// Инициализирует цвета.
        /// </summary>
        private void InitializeColors()
        {
            _primaryColorDictionary = GetColorsDictionary(PrimaryColorResourceDictionary, PrimaryColorKey, _primaryColorWeights);
            _primaryForegroundColorDictionary = GetColorsDictionary(PrimaryColorResourceDictionary, PrimaryForegroundColorKey,
                _primaryForegroundColorWeights);
            _accentColorDictionary = GetColorsDictionary(AccentColorResourceDictionary, AccentColorKey, _accentColorWeights);
            _accentForegroundColorDictionary = GetColorsDictionary(AccentColorResourceDictionary, AccentForegroundColorKey, _accentForegroundColorWeights);
        }

        /// <summary>
        ///     Получает словарь цветов по заданному словарю и ключу свойств.
        /// </summary>
        /// <param name="dictionary">Словарь.</param>
        /// <param name="key">Ключ.</param>
        /// <param name="weights">Веса.</param>
        /// <returns>Словарь цветов.</returns>
        private static Dictionary<int, Color> GetColorsDictionary(ResourceDictionary dictionary, string key, int[] weights)
        {
            var result = new Dictionary<int, Color>();

            foreach (var weight in weights)
                result.Add(weight, GetColorFromResourceDictionary(dictionary, key, weight));

            return result;
        }

        /// <summary>
        ///     Получает цвет из заданного словаря по заданному ключу и весу.
        /// </summary>
        /// <param name="dictionary">Словарь ресурсов.</param>
        /// <param name="key">Ключ.</param>
        /// <param name="weight">Вес.</param>
        /// <returns>Цвет.</returns>
        private static Color GetColorFromResourceDictionary(ResourceDictionary dictionary, string key, int weight)
        {
            var currentKey = key + "-" + weight;
            var color = (System.Windows.Media.Color)dictionary[currentKey];
            return Extensions.Color.ToFluidColor(color);
        }
    }
}