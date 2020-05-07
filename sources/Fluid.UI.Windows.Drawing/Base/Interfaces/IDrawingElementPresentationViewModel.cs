using System;
using System.Collections.Generic;
using Fluid.Presentation.Interfaces;

namespace Fluid.UI.Windows.Drawing.Base.Interfaces
{
    /// <summary>
    /// Interface for drawing element presentation view model.
    /// </summary>
    public interface IDrawingElementPresentationViewModel : IPresentationViewModel, IDisposable
    {
        /// <summary>
        ///     Gets collection of drawing object.
        /// </summary>
        ICollection<IDrawingObject> DrawingObjects { get; }

        /// <summary>
        /// Adds drawing object.
        /// </summary>
        /// <param name="obj">Drawing object.</param>
        void AddDrawingObject(IDrawingObject obj);

        /// <summary>
        /// Removes drawing object.
        /// </summary>
        /// <param name="obj">Drawing object.</param>
        void RemoveDrawingObject(IDrawingObject obj);

        /// <summary>
        /// Updates canvas.
        /// </summary>
        void Update();

        /// <summary>
        /// Clears drawing objects.
        /// </summary>
        void Clear();
    }
}