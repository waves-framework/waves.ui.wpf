using System;
using Fluid.Core.Base;
using Fluid.UI.Windows.Drawing.Extensions;
using SkiaSharp;

namespace Fluid.UI.Windows.Drawing.Base.Primitives
{
    /// <summary>
    /// Line.
    /// </summary>
    public class Line : DrawingObject
    {
        /// <inheritdoc />
        public override string Name { get; set; } = "Line";

        /// <inheritdoc />
        public override Size Size => new Size(Math.Abs(Point2.X - Point1.X), Math.Abs(Point2.Y - Point1.Y));

        /// <summary>
        ///     Gets or sets first point.
        /// </summary>
        public Point Point1 { get; set; }

        /// <summary>
        ///     Gets or sets second point.
        /// </summary>
        public Point Point2 { get; set; }

        /// <summary>
        ///     Gets or sets dash pattern.
        /// </summary>
        public float[] DashPattern { get; set; } = { 0, 0, 0, 0 };

        /// <inheritdoc />
        public override void Draw(SKCanvas canvas)
        {
            if (!IsVisible) return;

            using (var paint = new SKPaint
                {Color = Fill.ToSkColor(Opacity), IsAntialias = IsAntialiased})
            {
                GetDashArray(paint);
                canvas.DrawLine(Point1.ToSkPoint(), Point2.ToSkPoint(), paint);
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
                GetDashArray(paint);
                canvas.DrawLine(Point1.ToSkPoint(), Point2.ToSkPoint(), paint);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }

        /// <summary>
        /// Gets dash array.
        /// </summary>
        /// <param name="paint">SKPaint.</param>
        private void GetDashArray(SKPaint paint)
        {
            if (DashPattern != null)
            {
                var dashEffect = SKPathEffect.CreateDash(DashPattern, 0);
                paint.PathEffect = paint.PathEffect != null
                    ? SKPathEffect.CreateCompose(dashEffect, paint.PathEffect)
                    : dashEffect;
            }
        }
    }
}