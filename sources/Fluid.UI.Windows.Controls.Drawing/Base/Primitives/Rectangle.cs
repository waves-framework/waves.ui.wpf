using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Extensions;
using SkiaSharp;

namespace Fluid.UI.Windows.Controls.Drawing.Base.Primitives
{
    /// <summary>
    /// Rectangle.
    /// </summary>
    public class Rectangle : ShapeDrawingObject
    {
        /// <inheritdoc />
        public override string Name { get; set; } = "Rectangle";

        /// <inheritdoc />
        public override Size Size => new Size(Width, Height);

        /// <summary>
        /// Gets or sets corner radius.
        /// </summary>
        public float CornerRadius { get; set; }

        /// <inheritdoc />
        public override void Draw(SKCanvas canvas)
        {
            if (!IsVisible) return;

            using (var paint = new SKPaint { Color = Fill.ToSkColor(Opacity), IsAntialias = IsAntialiased })
            {
                canvas.DrawRoundRect(Location.X, Location.Y, Width, Height,
                    CornerRadius, CornerRadius, paint);
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
                canvas.DrawRoundRect(Location.X, Location.Y, Width, Height,
                    CornerRadius, CornerRadius, paint);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}