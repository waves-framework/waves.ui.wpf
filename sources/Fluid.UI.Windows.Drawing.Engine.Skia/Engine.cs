using System.Composition;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.View.Interface;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
using Fluid.UI.Windows.Drawing.Engine.Skia.View;

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
        public IDrawingElement GetDrawingElement()
        {
            return new SkiaDrawingElement();
        }
    }
}