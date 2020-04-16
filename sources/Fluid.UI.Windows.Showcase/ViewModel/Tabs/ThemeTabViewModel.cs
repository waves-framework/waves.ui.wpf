using Fluid.Presentation.Base;
using Fluid.UI.Windows.Services.Interfaces;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Theme tab view model.
    /// </summary>
    public class ThemeTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Gets theme service.
        /// </summary>
        public IThemeService ThemeService { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            ThemeService = App.Core.GetService<IThemeService>();
        }
    }
}