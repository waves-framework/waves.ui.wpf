using System.Collections.Generic;

namespace Fluid.UI.Windows.Services.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса тем.
    /// </summary>
    public interface IThemeService
    {
        /// <summary>
        /// Выбранная тема.
        /// </summary>
        ITheme SelectedTheme { get; }

        /// <summary>
        /// Коллекция тем.
        /// </summary>
        ICollection<ITheme> Themes { get; }
    }
}