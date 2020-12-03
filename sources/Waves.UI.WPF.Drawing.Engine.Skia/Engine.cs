using System;
using System.Composition;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Drawing.Base.Interfaces;
using Waves.UI.Drawing.View.Interfaces;
using Waves.UI.WPF.Drawing.Engine.Skia.View;

namespace Waves.UI.WPF.Drawing.Engine.Skia
{
    /// <summary>
    ///     Engine.
    /// </summary>
    [Export(typeof(IDrawingEngine))]
    public class Engine : WavesObject, IDrawingEngine
    {
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "SKIA";

        /// <inheritdoc />
        public IDrawingElementPresenterView GetView(IInputService inputService)
        {
            return new SkiaDrawingElementView(inputService);
        }

        /// <inheritdoc />
        public IDrawingElement GetDrawingElement()
        {
            return new SkiaDrawingElement();
        }
        
        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}