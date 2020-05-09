using Fluid.UI.Windows.Controls.Drawing.Charting.View.Interface;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Base.Interfaces
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
        /// Gets whether is drawing supported.
        /// </summary>
        bool IsDrawingSupported { get; }

        /// <summary>
        /// Gets whether is data set charts drawing supported.
        /// </summary>
        bool IsDataSetChartsDrawingSupported { get; }

        /// <summary>
        /// Gets new instance of drawing element view.
        /// </summary>
        /// <returns>Instance of drawing element.</returns>
        IDrawingElementView GetView();

        /// <summary>
        /// Gets new instance of drawing element view model.
        /// </summary>
        /// <returns>Instance of drawing element view model.</returns>
        IDrawingElementViewModel GetViewModel();

        /// <summary>
        /// Gets new instance of chart view.
        /// </summary>
        /// <returns>Chart view.</returns>
        IChartView GetChartView();

        /// <summary>
        /// Gets new instance of chart view model.
        /// </summary>
        /// <returns>Instance of chart view model.</returns>
        IChartViewModel GetChartViewModel();
    }
}