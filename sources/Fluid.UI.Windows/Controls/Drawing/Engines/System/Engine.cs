using System.Composition;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Engines.System.View;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Engines.System
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
        public IDrawingElementView GetView()
        {
            return new SystemDrawingElementView();
        }

        /// <inheritdoc />
        public IDrawingElement GetDrawingElement()
        {
            return new SystemDrawingElement();
        }
    }
}