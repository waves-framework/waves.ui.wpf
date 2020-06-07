using System.Composition;
using Waves.Core.Services.Interfaces;
using Waves.UI.Drawing.Base.Interfaces;
using Waves.UI.Drawing.View.Interfaces;
using Waves.UI.WPF.Controls.Drawing.Engines.System.View;

namespace Waves.UI.WPF.Controls.Drawing.Engines.System
{
    /// <summary>
    ///     Engine.
    /// </summary>
    [Export(typeof(IDrawingEngine))]
    public class Engine : IDrawingEngine
    {
        /// <inheritdoc />
        public string Name => "System";

        /// <inheritdoc />
        public IDrawingElementView GetView(IInputService inputService)
        {
            return new SystemDrawingElementView(inputService);
        }

        /// <inheritdoc />
        public IDrawingElement GetDrawingElement()
        {
            return new SystemDrawingElement();
        }
    }
}