namespace Fluid.UI.Windows.Drawing.Base.Interfaces
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
        /// <returns>Instance of drawing element.</returns>
        IDrawingElementPresentationView GetView();

        /// <summary>
        /// Gets new instance of drawing element view model.
        /// </summary>
        /// <returns>Instance of drawing element view model.</returns>
        IDrawingElementPresentationViewModel GetViewModel();
    }
}