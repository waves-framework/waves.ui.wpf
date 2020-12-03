using System;
using System.Composition;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Drawing.Base.Interfaces;
using Waves.UI.Drawing.View.Interfaces;
using Waves.UI.WPF.Controls.Drawing.Engines.System.View;

namespace Waves.UI.WPF.Controls.Drawing.Engines.System
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
        public override string Name { get; set; } = "System";

        /// <inheritdoc />
        public IDrawingElementPresenterView GetView(IInputService inputService)
        {
            return new SystemDrawingElementView(inputService);
        }

        /// <inheritdoc />
        public IDrawingElement GetDrawingElement()
        {
            return new SystemDrawingElement();
        }
        
        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}