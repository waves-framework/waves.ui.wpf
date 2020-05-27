using System.Composition;
using Waves.Core.Services.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Base.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Engines.System.View;
using Waves.UI.Windows.Controls.Drawing.View.Interfaces;

namespace Waves.UI.Windows.Controls.Drawing.Engines.System
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