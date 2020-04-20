using System;
using System.Collections.ObjectModel;
using System.Composition;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Services.Interfaces;
using Microsoft.Win32;
using Application = System.Windows.Application;

namespace Fluid.UI.Windows.Services
{
    /// <summary>
    ///     Windows UI theme service.
    /// </summary>
    [Export(typeof(IService))]
    public class ThemeService : Fluid.Core.Base.Service, IThemeService
    {
        private const string PrimaryLightColorsDictionaryUri = "/Fluid.UI.Windows;component/Colors/Primary.Light.xaml";
        private const string PrimaryDarkColorsDictionaryUri = "/Fluid.UI.Windows;component/Colors/Primary.Dark.xaml";
        private const string AccentBlueColorsDictionaryUri = "/Fluid.UI.Windows;component/Colors/Accent.Blue.xaml";
        private const string AccentGreenColorsDictionaryUri = "/Fluid.UI.Windows;component/Colors/Accent.Green.xaml";
        private const string AccentRedColorsDictionaryUri = "/Fluid.UI.Windows;component/Colors/Accent.Red.xaml";
        private const string AccentYellowColorsDictionaryUri = "/Fluid.UI.Windows;component/Colors/Accent.Yellow.xaml";
        private const string MiscellaneousColorsDictionaryUri ="/Fluid.UI.Windows;component/Colors/Miscellaneous.Classic.xaml";

        private readonly object _themesCollectionLocker = new object();

        private Application _application;

        private bool _isSystemUsingDarkTheme;
        private ResourceDictionary _oldAccentResourceDictionary;
        private ResourceDictionary _oldMiscellaneousResourceDictionary;

        private ResourceDictionary _oldPrimaryResourceDictionary;

        private ITheme _selectedTheme;
        private Guid _selectedThemeId = Guid.Empty;
        private bool _useAutomaticScheme = true;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("61482A15-667C-4993-AEAE-4F19A62C17B8");

        /// <inheritdoc />
        public override string Name { get; set; } = "Windows UI Theme Service";

        /// <inheritdoc />
        public bool UseAutomaticScheme
        {
            get => _useAutomaticScheme;
            set
            {
                _useAutomaticScheme = value;

                if (value)
                    InitializeSystemThemeCheckerDaemon();
            }
        }

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
        public ObservableCollection<ITheme> Themes { get; } = new ObservableCollection<ITheme>();

        /// <inheritdoc />
        public void AttachApplication(Application application)
        {
            _application = application;

            InitializeSelectedTheme();
            InitializeSystemThemeCheckerDaemon();

            OnMessageReceived(this,
                new Message("Initialization", "Application attached.", Name, MessageType.Information));
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            InitializeCollectionSynchronization();
            InitializeThemes();

            OnMessageReceived(this,
                new Message("Initialization", "Service was initialized.", Name, MessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
            try
            {
                _selectedThemeId = LoadConfigurationValue(configuration, "ThemesService-SelectedThemeId", Guid.Empty);
                UseAutomaticScheme = LoadConfigurationValue(configuration, "ThemesService-UseAutomaticScheme", false);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error loading configuration:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
            try
            {
                configuration.SetPropertyValue("ThemesService-SelectedThemeId", _selectedThemeId);
                configuration.SetPropertyValue("ThemesService-UseAutomaticScheme", UseAutomaticScheme);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error saving configuration:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            // 
        }

        /// <summary>
        ///     Initializes system theme checker daemon.
        /// </summary>
        private void InitializeSystemThemeCheckerDaemon()
        {
            if (!UseAutomaticScheme) return;

            Task.Run(async delegate
            {
                do
                {
                    try
                    {
                        var value = (int) Registry.GetValue(
                            @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
                            "AppsUseLightTheme", "1");

                        _isSystemUsingDarkTheme = value != 1;

                        await Task.Delay(2500).ConfigureAwait(false);

                        if (!UseAutomaticScheme)
                            break;

                        if (_isSystemUsingDarkTheme && SelectedTheme.IsDark) continue;
                        if (!_isSystemUsingDarkTheme && !SelectedTheme.IsDark) continue;

                        _application.Dispatcher.Invoke(delegate
                        {
                            foreach (var theme in Themes)
                                if (_isSystemUsingDarkTheme)
                                {
                                    if (theme.IsDark)
                                    {
                                        SelectedTheme = theme;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (!theme.IsDark)
                                    {
                                        SelectedTheme = theme;
                                        return;
                                    }
                                }
                        });
                    }
                    catch (Exception e)
                    {
                        OnMessageReceived(this,
                            new Message("Theme Service", "Error checking system theme:\r\n" + e, Name,
                                MessageType.Error));
                    }
                } while (UseAutomaticScheme);
            });
        }

        /// <summary>
        ///     Initializes collection synchronization.S
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            try
            {
                BindingOperations.EnableCollectionSynchronization(Themes, _themesCollectionLocker);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error enabling collection synchronization:\r\n" + e, Name,
                        MessageType.Error));
            }
        }

        /// <summary>
        ///     Initializes themes.
        /// </summary>
        private void InitializeThemes()
        {
            try
            {
                Themes.Clear();
                InitializeBaseThemes();
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error initializing base themes:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <summary>
        ///     Initialized selected theme.
        /// </summary>
        private void InitializeSelectedTheme()
        {
            if (Themes.Count > 0)
                try
                {
                    if (_selectedThemeId.Equals(Guid.Empty))
                        SelectedTheme = Themes[0];
                    else
                        foreach (var theme in Themes)
                        {
                            if (theme.Id != _selectedThemeId) continue;
                            SelectedTheme = theme;
                            break;
                        }
                }
                catch (Exception e)
                {
                    OnMessageReceived(this,
                        new Message("Theme Service", "Error initializing selected theme:\r\n" + e, Name,
                            MessageType.Error));
                }
            else
                OnMessageReceived(this, new Message("Theme Service", "Themes not found.", Name, MessageType.Error));
        }

        /// <summary>
        ///     Initializes base themes.
        /// </summary>
        private void InitializeBaseThemes()
        {
            try
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
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    true));

                Themes.Add(new Theme("Dark / Green", Guid.Parse("B0976F22-9812-4CD4-9A48-D50C89751FE8"),
                    new ResourceDictionary
                    {
                        Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    true));

                Themes.Add(new Theme("Dark / Red", Guid.Parse("77C4FC42-C9AC-435A-9FA6-16208CA94FA9"),
                    new ResourceDictionary
                    {
                        Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    true));

                Themes.Add(new Theme("Dark / Yellow", Guid.Parse("56A2C1ED-6F69-45A9-AE3E-972A77340CAF"),
                    new ResourceDictionary
                    {
                        Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    true));

                Themes.Add(new Theme("Light / Blue", Guid.Parse("27D324B4-3279-481C-899B-153A60BAC3D0"),
                    new ResourceDictionary
                    {
                        Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    false));

                Themes.Add(new Theme("Light / Green", Guid.Parse("C8AD5DCD-5E81-41C1-A18F-4C5DEA11B800"),
                    new ResourceDictionary
                    {
                        Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    false));

                Themes.Add(new Theme("Light / Red", Guid.Parse("D7E3FCC7-6375-4994-ABE9-266CEA4DD576"),
                    new ResourceDictionary
                    {
                        Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    false));

                Themes.Add(new Theme("Light / Yellow", Guid.Parse("B42FC3FE-8022-4D0D-8D02-86540BD68862"),
                    new ResourceDictionary
                    {
                        Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    new ResourceDictionary
                    {
                        Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
                    },
                    false));

                OnMessageReceived(this,
                    new Message("Initialization", "Base themes initialized.", Name, MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error initializing base themes:\r\n" + e, Name, MessageType.Error));
            }
        }

        /// <summary>
        ///     Updates theme.
        /// </summary>
        private void UpdateTheme()
        {
            if (_application == null) return;

            try
            {
                var dictionaries = _application.Resources.MergedDictionaries;

                _application.Resources.BeginInit();

                if (dictionaries.Count > 1)
                {
                    dictionaries.Remove(_oldPrimaryResourceDictionary);
                    dictionaries.Remove(_oldAccentResourceDictionary);
                    dictionaries.Remove(_oldMiscellaneousResourceDictionary);
                }

                dictionaries.Add(SelectedTheme.PrimaryColorResourceDictionary);
                dictionaries.Add(SelectedTheme.AccentColorResourceDictionary);
                dictionaries.Add(SelectedTheme.MiscellaneousResourceDictionary);

                _oldPrimaryResourceDictionary = SelectedTheme.PrimaryColorResourceDictionary;
                _oldAccentResourceDictionary = SelectedTheme.AccentColorResourceDictionary;
                _oldMiscellaneousResourceDictionary = SelectedTheme.MiscellaneousResourceDictionary;

                _application.Resources.EndInit();

                OnMessageReceived(this, new Message("Theme Service", "Theme changed.", Name, MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new Message("Theme Service", "Error updating theme:\r\n" + e, Name, MessageType.Error));
            }
        }
    }
}