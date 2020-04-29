using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.ViewModel;
using Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.ViewModel.Interfaces;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// View model for charts tab.
    /// </summary>
    public class ChartingTabViewModel : PresentationViewModel
    {
        public ICanvasViewModel Canvas { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            Canvas = new CanvasViewModel();
        }
    }
}