using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Fluid.Core.Services.Interfaces;

namespace Fluid.UI.Windows.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса тем.
    /// </summary>
    public interface IThemeService : IService
    {
        /// <summary>
        /// Gets or sets primary color dictionary.
        /// </summary>
        ResourceDictionary PrimaryColorDictionary { get; set; }

        /// <summary>
        /// Gets or sets accent color dictionary.
        /// </summary>
        ResourceDictionary AccentColorDictionary { get; set; }

        /// <summary>
        /// Gets or sets miscellaneous color dictionary.
        /// </summary>
        ResourceDictionary MiscellaneousColorDictionary { get; set; }

        /// <summary>
        /// Выбранная тема.
        /// </summary>
        ITheme SelectedTheme { get; }

        /// <summary>
        /// Коллекция тем.
        /// </summary>
        ObservableCollection<ITheme> Themes { get; }
    }
}