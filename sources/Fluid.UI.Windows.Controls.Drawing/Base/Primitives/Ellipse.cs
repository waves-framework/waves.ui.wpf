using System.ComponentModel;
using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Extensions;
using SkiaSharp;

namespace Fluid.UI.Windows.Controls.Drawing.Base.Primitives
{
    /// <summary>
    /// Ellipse.
    /// </summary>
    public class Ellipse : ShapeDrawingObject
    {
        /// <inheritdoc />
        public override string Name { get; set; } = "Ellipse";

        /// <inheritdoc />
        public override Size Size => new Size(Width, Height);

        /// <summary>
        /// Gets or sets ellipse radius.
        /// </summary>
        public float Radius { get; set; }

        /// <inheritdoc />
        public override void Draw(SKCanvas canvas)
        {
            if (!IsVisible) return;

            using (var paint = new SKPaint { Color = Fill.ToSkColor(Opacity), IsAntialias = IsAntialiased})
            {
                canvas.DrawCircle(Location.X, Location.Y, Radius, paint);
            }

            if (!(StrokeThickness > 0)) return;

            using (var paint = new SKPaint
            {
                Color = Stroke.ToSkColor(Opacity),
                IsStroke = true,
                StrokeWidth = StrokeThickness,
                IsAntialias = IsAntialiased
            })
            {
                canvas.DrawCircle(Location.X, Location.Y, Radius, paint);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}