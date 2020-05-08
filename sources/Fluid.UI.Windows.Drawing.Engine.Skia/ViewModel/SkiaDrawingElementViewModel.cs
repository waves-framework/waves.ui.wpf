using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
using Fluid.UI.Windows.Drawing.Engine.Skia.View;
using SkiaSharp;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.ViewModel
{
    /// <summary>
    ///     Drawing canvas view model.
    /// </summary>
    public class SkiaDrawingElementViewModel : DrawingElementViewModel<SKSurface>
    {
        private SkiaDrawingElement _drawingElement;

        /// <inheritdoc />
        public override void Draw(SKSurface element)
        {
            if (_drawingElement == null)
            {
                _drawingElement = new SkiaDrawingElement(element);
            }
            else
            {
                if (_drawingElement.Surface == null) _drawingElement.Surface = element;

                if (_drawingElement.Surface.Handle == IntPtr.Zero) _drawingElement.Surface = element;
            }

            element.Canvas.Clear(SKColor.Empty);

            foreach (var obj in DrawingObjects)
                obj.Draw(_drawingElement);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}