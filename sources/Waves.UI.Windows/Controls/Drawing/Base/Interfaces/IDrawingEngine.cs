using Waves.Core.Services.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Charting.View.Interface;
using Waves.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Waves.UI.Windows.Controls.Drawing.View.Interfaces;
using Waves.UI.Windows.Controls.Drawing.ViewModel.Interfaces;

namespace Waves.UI.Windows.Controls.Drawing.Base.Interfaces
{
    /// <summary>
    /// Interface for drawing engine.
    /// </summary>
    public interface IDrawingEngine
    {
        /// <summary>
        /// Gets name of engine.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets new instance of drawing element view.
        /// </summary>
        /// <param name="inputService">Input service.</param>
        /// <returns>Instance of drawing element.</returns>
        IDrawingElementView GetView(IInputService inputService);

        /// <summary>
        /// Gets drawing element.
        /// </summary>
        /// <returns>Drawing element.</returns>
        IDrawingElement GetDrawingElement();
    }
}