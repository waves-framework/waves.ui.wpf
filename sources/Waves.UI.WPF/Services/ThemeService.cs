using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Composition;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.UI.WPF.Base;
using Microsoft.Win32;
using ReactiveUI;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Base.Interfaces;
using Waves.UI.Services.Interfaces;
using Application = System.Windows.Application;

namespace Waves.UI.WPF.Services
{
    /// <summary>
    ///     Windows UI theme service.
    /// </summary>
    [Export(typeof(IWavesService))]
    public class ThemeService : WavesService, IThemeService
    {
        //    /// <summary>
        //    ///     Initializes system theme checker daemon.
        //    /// </summary>
        //    private void InitializeSystemThemeCheckerDaemon()
        //    {
        //        if (!UseAutomaticScheme) return;

        //        Task.Run(async delegate
        //        {
        //            do
        //            {
        //                try
        //                {
        //                    var value = (int) Registry.GetValue(
        //                        @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize",
        //                        "AppsUseLightTheme", "1");

        //                    _isSystemUsingDarkTheme = value != 1;

        //                    await Task.Delay(2500).ConfigureAwait(false);

        //                    if (!UseAutomaticScheme)
        //                        break;

        //                    if (_isSystemUsingDarkTheme && SelectedTheme.IsDark) continue;
        //                    if (!_isSystemUsingDarkTheme && !SelectedTheme.IsDark) continue;

        //                    _application.Dispatcher.Invoke(delegate
        //                    {
        //                        foreach (var theme in Themes)
        //                            if (_isSystemUsingDarkTheme)
        //                            {
        //                                if (theme.IsDark)
        //                                {
        //                                    SelectedTheme = theme;
        //                                    return;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (!theme.IsDark)
        //                                {
        //                                    SelectedTheme = theme;
        //                                    return;
        //                                }
        //                            }
        //                    });
        //                }
        //                catch (Exception e)
        //                {
        //                    OnMessageReceived(this,
        //                        new Message("Theme Service", "Error checking system theme:\r\n" + e, Name,
        //                            MessageType.Error));
        //                }
        //            } while (UseAutomaticScheme);
        //        });
        //    }

        //    /// <summary>
        //    /// Gets color by brightness index.
        //    /// </summary>
        //    /// <param name="color">Original color.</param>
        //    /// <param name="index">Brightness index.</param>
        //    /// <returns>Color.</returns>
        //    private static System.Windows.Media.Color GetColor(System.Windows.Media.Color color, float index)
        //    {
        //        var a = (float)255;
        //        var r = color.R * index;
        //        var g = color.G * index;
        //        var b = color.B * index;

        //        if (a > 255) a = 255;
        //        if (a < 0) a = 0;

        //        if (r > 255) r = 255;
        //        if (r < 0) r = 0;

        //        if (g > 255) g = 255;
        //        if (g < 0) g = 0;

        //        if (b > 255) b = 255;
        //        if (b < 0) b = 0;

        //        var ab = (byte)a;
        //        var rb = (byte)r;
        //        var gb = (byte)g;
        //        var bb = (byte)b;

        //        return System.Windows.Media.Color.FromArgb(ab, rb, gb, bb);
        //    }
        //}

        private const string PrimaryLightColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Primary.Light.xaml";
        private const string PrimaryDarkColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Primary.Dark.xaml";
        private const string AccentWhiteColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.White.xaml";
        private const string AccentBlackColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Haiti.xaml";
        private const string AccentBlueColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Picton.Blue.xaml";
        private const string AccentGreenColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Jade.xaml";
        private const string AccentRedColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Sunset.Orange.xaml";
        private const string AccentYellowColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Ronchi.xaml";
        private const string AccentTemplateDictionaryUri = "/Waves.UI.WPF;component/Colors/Accent.Template.xaml";
        private const string MiscellaneousColorsDictionaryUri = "/Waves.UI.WPF;component/Colors/Miscellaneous.Classic.xaml";

        private readonly object _themesCollectionLocker = new object();

        private bool _useDarkScheme = false;

        private ResourceDictionary _oldPrimaryResourceDictionary;
        private ResourceDictionary _oldAccentResourceDictionary;
        private ResourceDictionary _oldMiscellaneousResourceDictionary;

        private Guid _selectedThemeId = Guid.Empty;

        private ITheme _selectedTheme;

        private Application _application;
        
        /// <inheritdoc />
        public event EventHandler ThemeChanged;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("61482A15-667C-4993-AEAE-4F19A62C17B8");

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF UI Theme Service";

        /// <inheritdoc />
        public bool UseDarkScheme
        {
            get => _useDarkScheme;
            set
            {
                if (_useDarkScheme.Equals(value)) return;
                
                this.RaiseAndSetIfChanged(ref _useDarkScheme, value);
                
                UpdateTheme();

                OnThemeChanged();
            }
        }

        /// <inheritdoc />
        public bool UseAutomaticScheme { get; set; } = true;

        /// <inheritdoc />
        public ITheme SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (value == null) return;

                if (value.Equals(_selectedTheme)) return;

                var useDarkSet = false;
                if (_selectedTheme != null)
                    useDarkSet = _selectedTheme.UseDarkSet;

                this.RaiseAndSetIfChanged(ref _selectedTheme, value);

                _selectedThemeId = _selectedTheme.Id;

                _selectedTheme.UseDarkSet = useDarkSet;

                UpdateTheme();

                OnThemeChanged();
            }
        }

        /// <inheritdoc />
        public ObservableCollection<ITheme> Themes { get; private set; } = new ObservableCollection<ITheme>();

        /// <summary>
        /// Attaches application.
        /// </summary>
        /// <param name="application">Application.</param>
        public void AttachApplication(Application application)
        {
            _application = application;

            InitializeSelectedTheme();
            //InitializeSystemThemeCheckerDaemon();

            OnMessageReceived(this,
                new WavesMessage("Initialization", "Application attached - " + application, Name, WavesMessageType.Information));
        }

        /// <inheritdoc />
        public override void Initialize(IWavesCore core)
        {
            if (IsInitialized) return;

            Core = core;

            InitializeCollectionSynchronization();
            InitializeThemes();

            OnMessageReceived(this,
                new WavesMessage("Initialization", "Service was initialized.", Name, WavesMessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration()
        {
            try
            {
                _selectedThemeId = LoadConfigurationValue(Core.Configuration, "ThemesService-SelectedThemeId", Guid.Empty);
                UseAutomaticScheme = LoadConfigurationValue(Core.Configuration, "ThemesService-UseAutomaticScheme", false);
                UseDarkScheme = LoadConfigurationValue(Core.Configuration, "ThemesService-UseDarkScheme", false);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new WavesMessage("Theme Service", "Error loading configuration:\r\n" + e, Name, WavesMessageType.Error));
            }
        }

        /// <inheritdoc />
        public override void SaveConfiguration()
        {
            try
            {
                Core.Configuration.SetPropertyValue("ThemesService-SelectedThemeId", _selectedThemeId);
                Core.Configuration.SetPropertyValue("ThemesService-UseAutomaticScheme", UseAutomaticScheme);
                Core.Configuration.SetPropertyValue("ThemesService-UseDarkScheme", UseDarkScheme);
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new WavesMessage("Theme Service", "Error saving configuration:\r\n" + e, Name, WavesMessageType.Error));
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            Themes.Clear();
        }

        /// <summary>
        /// Notifies when theme changed.
        /// </summary>
        protected virtual void OnThemeChanged()
        {
            ThemeChanged?.Invoke(this, EventArgs.Empty);
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
                    new WavesMessage("Theme Service", "Error enabling collection synchronization:\r\n" + e, Name,
                        WavesMessageType.Error));
            }
        }

        /// <summary>
        /// Initializes themes.
        /// </summary>
        private void InitializeThemes()
        {
            try
            {
                Themes.Clear();

                InitializeBaseThemes();

                if (Themes.Count == 0)
                    throw new Exception("Themes were not loaded.");
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new WavesMessage("Theme Service", "Error initializing base themes:\r\n" + e, Name, WavesMessageType.Error));
            }
        }

        /// <summary>
        /// Initializes base themes.
        /// </summary>
        private void InitializeBaseThemes()
        {
            var lightPrimaryColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(PrimaryLightColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var darkPrimaryColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(PrimaryDarkColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentGreenColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentGreenColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentBlueColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentBlueColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentRedColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentRedColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var accentYellowColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(AccentYellowColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var miscellaneousColorsResourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(MiscellaneousColorsDictionaryUri, UriKind.RelativeOrAbsolute)
            };

            var primaryLightColorName = (string)lightPrimaryColorsResourceDictionary["ColorSetName"];
            var primaryDarkColorName = (string)darkPrimaryColorsResourceDictionary["ColorSetName"];
            var accentGreenColorName = (string)accentGreenColorsResourceDictionary["ColorSetName"];
            var accentBlueColorName = (string)accentBlueColorsResourceDictionary["ColorSetName"];
            var accentRedColorName = (string)accentRedColorsResourceDictionary["ColorSetName"];
            var accentYellowColorName = (string)accentYellowColorsResourceDictionary["ColorSetName"];
            var miscellaneousColorName = (string)miscellaneousColorsResourceDictionary["ColorSetName"];

            var primaryLightColorSetId = Guid.Parse((string)lightPrimaryColorsResourceDictionary["ColorSetId"]);
            var primaryDarkColorSetId = Guid.Parse((string)darkPrimaryColorsResourceDictionary["ColorSetId"]);
            var accentGreenColorSetId = Guid.Parse((string)accentGreenColorsResourceDictionary["ColorSetId"]);
            var accentBlueColorSetId = Guid.Parse((string)accentBlueColorsResourceDictionary["ColorSetId"]);
            var accentRedColorSetId = Guid.Parse((string)accentRedColorsResourceDictionary["ColorSetId"]);
            var accentYellowColorSetId = Guid.Parse((string)accentYellowColorsResourceDictionary["ColorSetId"]);
            var miscellaneousColorSetId = Guid.Parse((string)miscellaneousColorsResourceDictionary["ColorSetId"]);

                var lightPrimaryColorSet = new PrimaryColorSet(primaryLightColorSetId,
                primaryLightColorName,
                lightPrimaryColorsResourceDictionary);

            var darkPrimaryColorSet = new PrimaryColorSet(primaryDarkColorSetId,
                primaryDarkColorName,
                darkPrimaryColorsResourceDictionary);

            var greenAccentColorSet = new AccentColorSet(accentGreenColorSetId,
                accentGreenColorName,
                accentGreenColorsResourceDictionary);

            var blueAccentColorSet = new AccentColorSet(accentBlueColorSetId,
                accentBlueColorName,
                accentBlueColorsResourceDictionary);

            var redAccentColorSet = new AccentColorSet(accentRedColorSetId,
                accentRedColorName,
                accentRedColorsResourceDictionary);

            var yellowAccentColorSet = new AccentColorSet(accentYellowColorSetId,
                accentYellowColorName,
                accentYellowColorsResourceDictionary);

            var miscellaneousColorSet = new MiscellaneousColorSet(miscellaneousColorSetId,
                miscellaneousColorName,
                miscellaneousColorsResourceDictionary);

            Themes.Add(new Theme(
                Guid.Parse("12E87107-C2FC-4D68-908C-377B80A4056A"),
                accentGreenColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                greenAccentColorSet,
                miscellaneousColorSet));

            Themes.Add(new Theme(
                Guid.Parse("2549DD92-C094-4EF5-B50D-0DD187DFE154"),
                accentBlueColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                blueAccentColorSet,
                miscellaneousColorSet));

            Themes.Add(new Theme(
                Guid.Parse("07B33F24-141B-4D9A-9C3A-946B0FC6BC82"),
                accentRedColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                redAccentColorSet,
                miscellaneousColorSet));

            Themes.Add(new Theme(
                Guid.Parse("4F7E14EA-B219-40C6-8870-D9D080756D15"),
                accentYellowColorName,
                lightPrimaryColorSet,
                darkPrimaryColorSet,
                yellowAccentColorSet,
                miscellaneousColorSet));

            foreach (var theme in Themes)
            {
                theme.PrimaryColorSetChanged += OnThemePrimaryColorSetChanged;
            }
        }

        /// <summary>
        /// Actions when theme's primary color set changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnThemePrimaryColorSetChanged(object sender, EventArgs e)
        {
            UpdateTheme();

            UseDarkScheme = SelectedTheme.UseDarkSet;
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

                var primaryColorSet = SelectedTheme.PrimaryColorSet as PrimaryColorSet;
                if (primaryColorSet == null) return;

                var accentColorSet = SelectedTheme.AccentColorSet as AccentColorSet;
                if (accentColorSet == null) return;

                var miscellaneousColorSet = SelectedTheme.MiscellaneousColorSet as MiscellaneousColorSet;
                if (miscellaneousColorSet == null) return;

                dictionaries.Add(primaryColorSet.ResourceDictionary);
                dictionaries.Add(accentColorSet.ResourceDictionary);
                dictionaries.Add(miscellaneousColorSet.ResourceDictionary);

                _oldPrimaryResourceDictionary = primaryColorSet.ResourceDictionary;
                _oldAccentResourceDictionary = accentColorSet.ResourceDictionary;
                _oldMiscellaneousResourceDictionary = miscellaneousColorSet.ResourceDictionary;

                _application.Resources.EndInit();

                OnMessageReceived(this,
                    SelectedTheme.UseDarkSet
                        ? new WavesMessage("Theme Service", "Theme changed to \"" + SelectedTheme.Name + "\" (Dark).", Name,
                            WavesMessageType.Information)
                        : new WavesMessage("Theme Service", "Theme changed to \"" + SelectedTheme.Name + "\" (Light).", Name,
                            WavesMessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(this,
                    new WavesMessage("Theme Service", "Error updating theme:\r\n" + e, Name, WavesMessageType.Error));
            }
        }

        /// <summary>
        ///     Initialized selected theme.
        /// </summary>
        private void InitializeSelectedTheme()
        {
            if (Themes.Count > 0)
            {
                try
                {
                    if (_selectedThemeId.Equals(Guid.Empty))
                    {
                        SelectedTheme = Themes.First();
                    }
                    else
                    {
                        foreach (var theme in Themes)
                        {
                            if (theme.Id != _selectedThemeId) continue;

                            SelectedTheme = theme;

                            SelectedTheme.UseDarkSet = UseDarkScheme;

                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    OnMessageReceived(this,
                        new WavesMessage("Theme Service", "Error initializing selected theme:\r\n" + e, Name,
                            WavesMessageType.Error));
                }
            }
            else
            {
                OnMessageReceived(this, new WavesMessage("Theme Service", "Themes not found.", Name, WavesMessageType.Error));
            }
        }
    }
}