using System;
using Fluid.Core.Base;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using SkiaSharp;
using Object = Fluid.Core.Base.Object;

namespace Fluid.UI.Windows.Drawing.Base
{
    /// <summary>
    /// Base abstract class for drawing objects.
    /// </summary>
    public abstract class DrawingObject: Object, IDrawingObject
    {
        /// <inheritdoc />
        public override Guid Id { get; } = new Guid();

        /// <inheritdoc />
        public abstract override string Name { get; set; }

        /// <inheritdoc />
        public bool IsAntialiased { get; set; } = true;

        /// <inheritdoc />
        public bool IsVisible { get; set; } = true;

        /// <inheritdoc />
        public float Opacity { get; set; } = 1.0f;

        /// <inheritdoc />
        public float StrokeThickness { get; set; } = 1;

        /// <inheritdoc />
        public Color Fill { get; set; } = Color.Black;

        /// <inheritdoc />
        public Color Stroke { get; set; } = Color.Gray;

        /// <inheritdoc />
        public abstract Size Size { get; }

        /// <inheritdoc />
        public abstract void Draw(SKCanvas canvas);
    }
}