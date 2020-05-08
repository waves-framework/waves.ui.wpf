using System.Composition;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
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
        public IDrawingElementView GetView()
        {
            return new SkiaDrawingElementView();
        }

        /// <inheritdoc />
        public IDrawingElementViewModel GetViewModel()
        {
            return new SkiaDrawingElementViewModel();
        }
    }
}