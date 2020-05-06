using System;
using System.Collections.Generic;
using System.Windows.Input;
using Fluid.Core.Base;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Interfaces;
using SkiaSharp;

namespace Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.ViewModel.Interfaces
{
    /// <summary>
    /// Interface for drawing canvas.
    /// </summary>
    public interface ICanvasViewModel : IPresentationViewModel
    {
        /// <summary>
        /// Gets whether is drawing initialized.
        /// </summary>
        bool IsDrawingInitialized { get; }

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
        ///     Draws objects.
        /// </summary>
        void Draw();

        /// <summary>
        /// Clears drawing objects.
        /// </summary>
        void Clear();
    }
}