using System;
using Waves.Core.Base;
using Waves.UI.Windows.Controls.Drawing.Base.Interfaces;
using Object = Waves.Core.Base.Object;

namespace Waves.UI.Windows.Controls.Drawing.Base
{
    /// <summary>
    /// Base abstract class for drawing objects.
    /// </summary>
    public abstract class DrawingObject: Object, IDrawingObject
    {
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

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
        public abstract void Draw(IDrawingElement e);
    }
}