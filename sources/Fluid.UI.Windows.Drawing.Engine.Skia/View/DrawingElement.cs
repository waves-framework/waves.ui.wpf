using System;
using Fluid.Core.Base;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using SkiaSharp;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.View
{
    /// <summary>
    /// Skia drawing element.
    /// </summary>
    public class DrawingElement : IDrawingElement
    {
        private SKCanvas _canvas;

        /// <summary>
        /// Creates new instance of <see cref="DrawingElement"/>
        /// </summary>
        /// <param name="canvas"></param>
        public DrawingElement(SKCanvas canvas)
        {
            if (canvas != null)
                _canvas = null;
            else
                throw new ArgumentNullException(nameof(canvas));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _canvas?.Dispose();
        }

        /// <inheritdoc />
        public void DrawCircle(Point location, float radius, IPaint paint)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void DrawLine(Point point1, Point point2, IPaint paint)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void DrawRectangle(Point location, Size size, IPaint paint, float cornerRadius = 0)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void DrawText(Point location, string text, ITextPaint paint)
        {
            throw new System.NotImplementedException();
        }
    }
}