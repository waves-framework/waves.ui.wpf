using System.Composition;
using Waves.Core.Services.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Base.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Charting.View.Interface;
using Waves.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Waves.UI.Windows.Controls.Drawing.View.Interfaces;
using Waves.UI.Windows.Controls.Drawing.ViewModel;
using Waves.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
using Waves.UI.Windows.Drawing.Engine.Skia.View;

namespace Waves.UI.Windows.Drawing.Engine.Skia
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
        public IDrawingElementView GetView(IInputService inputService)
        {
            return new SkiaDrawingElementView(inputService);
        }

        /// <inheritdoc />
        public IDrawingElement GetDrawingElement()
        {
            return new SkiaDrawingElement();
        }
    }
}