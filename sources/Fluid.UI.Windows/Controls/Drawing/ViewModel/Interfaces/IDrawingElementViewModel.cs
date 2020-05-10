using System;
using System.Collections.Generic;
using Fluid.Core.Base;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces
{
    /// <summary>
    /// Interface for drawing element presentation view model.
    /// </summary>
    public interface IDrawingElementViewModel : IPresentationViewModel, IDisposable
    {
        /// <summary>
        /// Gets or sets foreground.
        /// </summary>
        Color Foreground { get; set; }

        /// <summary>
        /// Gets or sets background.
        /// </summary>
        Color Background { get; set; }

        /// <summary>
        /// Gets or sets drawing element.
        /// </summary>
        IDrawingElement DrawingElement { get; set; }

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
        /// Draws on element.
        /// </summary>
        void Draw(object element);

        /// <summary>
        /// Clears drawing objects.
        /// </summary>
        void Clear();
    }
}