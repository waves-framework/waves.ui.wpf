using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Fluid.Core.Services.Interfaces;

namespace Fluid.UI.Windows.Services.Interfaces
{
    /// <summary>
    /// Interface of theme service classes.
    /// </summary>
    public interface IThemeService : IService
    {
        /// <summary>
        /// Gets or sets selected theme.
        /// </summary>
        ITheme SelectedTheme { get; set; }

        /// <summary>
        /// Gets themes collection.
        /// </summary>
        ObservableCollection<ITheme> Themes { get; }

        /// <summary>
        /// Attaches application to service.
        /// </summary>
        /// <param name="application">Application instance.</param>
        void AttachApplication(Application application);
    }
}