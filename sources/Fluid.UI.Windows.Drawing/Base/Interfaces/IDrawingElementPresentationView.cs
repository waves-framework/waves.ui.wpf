using System;
using Fluid.Presentation.Interfaces;

namespace Fluid.UI.Windows.Drawing.Base.Interfaces
{
    /// <summary>
    /// Interface for drawing element presentation view.
    /// </summary>
    public interface IDrawingElementPresentationView : IPresentationView, IDisposable
    {
        /// <summary>
        /// Gets or sets drawing element.
        /// </summary>
        IDrawingElement DrawingElement { get; }
    }
}