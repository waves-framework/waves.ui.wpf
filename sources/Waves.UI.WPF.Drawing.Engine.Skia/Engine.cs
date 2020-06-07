using System.Composition;
using Waves.Core.Services.Interfaces;
using Waves.UI.Drawing.Base.Interfaces;
using Waves.UI.Drawing.View.Interfaces;
using Waves.UI.WPF.Drawing.Engine.Skia.View;

namespace Waves.UI.WPF.Drawing.Engine.Skia
{
    /// <summary>
    ///     Engine.
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