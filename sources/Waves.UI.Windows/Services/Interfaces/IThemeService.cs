using System.Collections.ObjectModel;
using System.Windows;
using Waves.Core.Base.Interfaces;
using Waves.Core.Services.Interfaces;
using Waves.UI.Windows.Base.Interfaces;

namespace Waves.UI.Windows.Services.Interfaces
{
    /// <summary>
    ///     Interface of theme service classes.
    /// </summary>
    public interface IThemeService : IService
    {
        /// <summary>
        ///     Gets or sets whether service sets automatic color scheme.
        /// </summary>
        bool UseAutomaticScheme { get; set; }

        /// <summary>
        ///     Gets or sets selected theme.
        /// </summary>
        ITheme SelectedTheme { get; set; }

        /// <summary>
        ///     Gets themes collection.
        /// </summary>
        ObservableCollection<ITheme> Themes { get; }

        /// <summary>
        ///     Attaches application to service.
        /// </summary>
        /// <param name="application">Application instance.</param>
        void AttachApplication(Application application);
    }
}