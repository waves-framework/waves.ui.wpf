using System.Composition;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Engine.Skia.View;
using Fluid.UI.Windows.Drawing.Engine.Skia.ViewModel;

namespace Fluid.UI.Windows.Drawing.Engine.Skia
{
    /// <summary>
    /// Engine.
    /// </summary>
    [Export(typeof(IDrawingEngine))]
    public class Engine : IDrawingEngine
    {
        /// <inheritdoc />
        public string Name => "SKIA";

        /// <inheritdoc />
        public IDrawingElementPresentationView GetView()
        {
            return new DrawingElementPresentationView();
        }

        /// <inheritdoc />
        public IDrawingElementPresentationViewModel GetViewModel()
        {
            return new DrawingElementPresentationViewModel();
        }
    }
}