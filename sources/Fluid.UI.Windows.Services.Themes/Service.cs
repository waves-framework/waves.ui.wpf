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
using Application = System.Windows.Application;

namespace Fluid.UI.Windows.Services.Themes
{
    /// <summary>
    /// Windows UI theme service.
    /// </summary>
    [Export(typeof(IService))]
    public class Service : Core.Services.Service, IThemeService
    {
        private Guid _selectedThemeId = Guid.Empty;

        private const string PrimaryLightColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Primary.Light.xaml";
        private const string PrimaryDarkColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Primary.Dark.xaml";
        private const string AccentBlueColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Blue.xaml";
        private const string AccentGreenColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Green.xaml";
        private const string AccentRedColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Red.xaml";
        private const string AccentYellowColorsDictionaryUri = "/Fluid.UI.Windows.Colors;component/Accent.Yellow.xaml";

        private readonly object _themesCollectionLocker = new object();

        private ResourceDictionary _oldPrimaryResourceDictionary;
        private ResourceDictionary _oldAccentResourceDictionary;
        private ResourceDictionary _oldMiscellaneousResourceDictionary;

        private ITheme _selectedTheme;

        private Application _application;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("61482A15-667C-4993-AEAE-4F19A62C17B8");

        /// <inheritdoc />
        public override string Name { get; set; } = "Windows UI Theme Service";

        /// <inheritdoc />
        public ITheme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (value == _selectedTheme) return;
                _selectedTheme = value;
                OnPropertyChanged();
                UpdateTheme();

                _selectedThemeId = _selectedTheme.Id;
            }
        }

        /// <inheritdoc />
        public ObservableCollection<ITheme> Themes { get; private set; } = new ObservableCollection<ITheme>();

        /// <inheritdoc />
        public void AttachApplication(Application application)
        {
            _application = application;

            OnMessageReceived(this, new Message("Initialization", "Application attached.", Name, MessageType.Information));

            InitializeSelectedTheme();
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            InitializeCollectionSynchronization();
            InitializeThemes();

            OnMessageReceived(this, new Message("Initialization", "Service was initialized.", Name, MessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
            _selectedThemeId = LoadConfigurationValue<Guid>(configuration, "ThemesService-SelectedThemeId", Guid.Empty);
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
            configuration.SetPropertyValue("ThemesService-SelectedThemeId", _selectedThemeId);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            // 
        }

        /// <summary>
        ///     Initializes collection synchronization.S
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(Themes, _themesCollectionLocker);
        }

        /// <summary>
        ///     Инициализация тем.
        /// </summary>
        private void InitializeThemes()
        {
            Themes.Clear();

            InitializeBaseThemes();
        }

        /// <summary>
        /// Initialized selected theme.
        /// </summary>
        private void InitializeSelectedTheme()
        {
            if (Themes.Count > 0)
            {
                if (_selectedThemeId.Equals(Guid.Empty))
                {
                    SelectedTheme = Themes[0];
                }
                else
                {
                    foreach (var theme in Themes)
                    {
                        if (theme.Id != _selectedThemeId) continue;
                        SelectedTheme = theme;
                        break;
                    }
                }
            }
            else
            {
                OnMessageReceived(this, new Message("Themes", "Themes not found.", Name, MessageType.Error));
            }
        }

        /// <summary>
        ///     Initializes base themes.
        /// </summary>
        private void InitializeBaseThemes()
        {
            Themes.Add(new Theme("Dark / Blue", Guid.Parse("39834D2D-42D3-4440-9109-F1C1175ECE22"), 
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Dark / Green", Guid.Parse("B0976F22-9812-4CD4-9A48-D50C89751FE8"),
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Dark / Red", Guid.Parse("77C4FC42-C9AC-435A-9FA6-16208CA94FA9"),
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Dark / Yellow", Guid.Parse("56A2C1ED-6F69-45A9-AE3E-972A77340CAF"),
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Blue", Guid.Parse("27D324B4-3279-481C-899B-153A60BAC3D0"),
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Green", Guid.Parse("C8AD5DCD-5E81-41C1-A18F-4C5DEA11B800"),
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Red", Guid.Parse("D7E3FCC7-6375-4994-ABE9-266CEA4DD576"),
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            Themes.Add(new Theme("Light / Yellow", Guid.Parse("B42FC3FE-8022-4D0D-8D02-86540BD68862"),
                new ResourceDictionary
                {
                    Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                new ResourceDictionary
                {
                    Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                },
                null));

            OnMessageReceived(this, new Message("Initialization", "Base themes initialized.", Name, MessageType.Information));
        }

        /// <summary>
        /// Updates theme.
        /// </summary>
        private void UpdateTheme()
        {
            if (_application == null) return;

            var dictionaries = _application.Resources.MergedDictionaries;

            _application.Resources.BeginInit();

            if (dictionaries.Count > 1)
            {
                dictionaries.Remove(_oldPrimaryResourceDictionary);
                dictionaries.Remove(_oldAccentResourceDictionary);
            }

            dictionaries.Add(SelectedTheme.PrimaryColorResourceDictionary);
            dictionaries.Add(SelectedTheme.AccentColorResourceDictionary);

            _oldPrimaryResourceDictionary = SelectedTheme.PrimaryColorResourceDictionary;
            _oldAccentResourceDictionary = SelectedTheme.AccentColorResourceDictionary;

            _application.Resources.EndInit();

            OnMessageReceived(this, new Message("Themes", "Theme changed.", Name, MessageType.Information));
        }
    }
}
