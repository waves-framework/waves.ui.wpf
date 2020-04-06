using System;
using System.Collections.ObjectModel;
using System.Composition;
using System.Windows;
using System.Windows.Data;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Base.Interfaces;
using Fluid.Core.Services.Interfaces;
using Fluid.UI.Windows.Services.Interfaces;

namespace Fluid.UI.Windows.Services.Themes
{
    /// <summary>
    /// Windows UI theme service.
    /// </summary>
    [Export(typeof(IService))]
    public class Service : Core.Services.Service, IThemeService
    {
        private const string PrimaryLightColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Primary.Light.xaml";
        private const string PrimaryDarkColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Primary.Dark.xaml";
        private const string AccentBlueColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Blue.xaml";
        private const string AccentGreenColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Green.xaml";
        private const string AccentRedColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Red.xaml";
        private const string AccentYellowColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Yellow.xaml";

        private readonly object _themesCollectionLocker = new object();

        private ITheme _selectedTheme;

        private ObservableCollection<ITheme> _themes = new ObservableCollection<ITheme>();

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("61482A15-667C-4993-AEAE-4F19A62C17B8");

        /// <inheritdoc />
        public override string Name { get; set; } = "Windows UI Theme Service";

        /// <inheritdoc />
        public ResourceDictionary PrimaryColorDictionary { get; set; }

        /// <inheritdoc />
        public ResourceDictionary AccentColorDictionary { get; set; }

        /// <inheritdoc />
        public ResourceDictionary MiscellaneousColorDictionary { get; set; }

        /// <inheritdoc />
        public ITheme SelectedTheme
        {
            get => _selectedTheme;
            private set
            {
                if (value == _selectedTheme) return;
                _selectedTheme = value;
                OnPropertyChanged();
                UpdateDictionaries();
            }
        }

        /// <inheritdoc />
        public ObservableCollection<ITheme> Themes
        {
            get => _themes;
            set
            {
                if (Equals(value, _themes)) return;
                _themes = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            InitializeCollectionSynchronization();
            InitializeThemes();

            OnMessageReceived(this,
                new Message("Информация", "Сервис инициализирован.", Name, MessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
            //
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
            //
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            //
        }

        /// <summary>
        ///     Инициализирует синхронизацию коллекций.
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(_themes, _themesCollectionLocker);
        }

        /// <summary>
        ///     Инициализация тем.
        /// </summary>
        private void InitializeThemes()
        {
            Themes.Clear();

            InitializeBaseThemes();

            if (Themes.Count > 0)
                SelectedTheme = Themes[0];
        }

        /// <summary>
        ///     Инициализация базовых тем.
        /// </summary>
        private void InitializeBaseThemes()
        {
            Themes.Add(new Theme("Dark / Blue",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Dark / Green",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Dark / Red",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Dark / Yellow",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Blue",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Green",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Red",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Yellow",
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));
        }

        /// <summary>
        /// Обновление словарей ресурсов.
        /// </summary>
        private void UpdateDictionaries()
        {
            PrimaryColorDictionary = SelectedTheme.PrimaryColorResourceDictionary;
            AccentColorDictionary = SelectedTheme.AccentColorResourceDictionary;
            MiscellaneousColorDictionary = SelectedTheme.MiscellaneousResourceDictionary;
        }
    }
}
