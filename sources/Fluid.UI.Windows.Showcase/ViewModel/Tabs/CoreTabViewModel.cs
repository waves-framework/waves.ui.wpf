using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Services.Interfaces;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Showcase.Services.Interfaces;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    ///     Core tab view model.
    /// </summary>
    public class CoreTabViewModel : PresentationViewModel
    {
        private ITextGeneratorService _textGeneratorService;

        /// <summary>
        ///     Gets logging service.
        /// </summary>
        public ILoggingService LoggingService { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            LoggingService = App.Core.GetService<ILoggingService>();

            _textGeneratorService = App.Core.GetService<ITextGeneratorService>();
        }
    }
}