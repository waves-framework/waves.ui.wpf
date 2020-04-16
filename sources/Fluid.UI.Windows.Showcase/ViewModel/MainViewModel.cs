using Fluid.Presentation.Base;
using Fluid.UI.Windows.Services.Interfaces;
using Bootstrapper = Fluid.Core.Core;

namespace Fluid.UI.Windows.Showcase.ViewModel
{
    public class MainViewModel : PresentationViewModel
    {
        public IThemeService ThemeService { get; set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            ThemeService = App.Core.GetService<IThemeService>();
        }
    }
}