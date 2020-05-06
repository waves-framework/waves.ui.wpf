using System;
using Fluid.Core.Base;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Extensions;
using SkiaSharp;

namespace Fluid.UI.Windows.Drawing.Base
{
    /// <summary>
    /// Line.
    /// </summary>
    public class Line : DrawingObject
    {
        /// <inheritdoc />
        public override string Name { get; set; } = "Line";

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
        public override void Draw(IDrawingElement e)
        {
            if (!IsVisible) return;

            using (var paint = new Paint() { Fill = Fill, IsAntialiased = IsAntialiased, Opacity = Opacity, DashPattern = DashPattern})
            {
                e.DrawLine(Point1, Point2, paint);
            }

            if (!(StrokeThickness > 0)) return;

            using (var paint = new Paint() { IsAntialiased = IsAntialiased, Opacity = Opacity, DashPattern = DashPattern, Stroke = Stroke, StrokeThickness = StrokeThickness })
            {
                e.DrawLine(Point1, Point2, paint);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}