using Fluid.Presentation.Base;
using Fluid.UI.Windows.Drawing.Presentation.Interfaces;
using Fluid.UI.Windows.Drawing.Services.Interfaces;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    ///     View model for charts tab.
    /// </summary>
    public class ChartingTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Gets drawing service.
        /// </summary>
        public IDrawingService DrawingService { get; private set; }

        /// <summary>
        /// Gets drawing element presentation.
        /// </summary>
        public IDrawingElementPresentation DrawingElementPresentation { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            DrawingService = App.Core.GetService<IDrawingService>();
            DrawingElementPresentation = DrawingService.CreatePresentation();
            DrawingElementPresentation.Initialize();
        }
    }
}