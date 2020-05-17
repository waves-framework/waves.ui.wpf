using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Base
{
    /// <summary>
    ///     Line.
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
        public float[] DashPattern { get; set; } = {0, 0, 0, 0};

        /// <inheritdoc />
        public override void Draw(IDrawingElement e)
        {
            if (!IsVisible) return;

            using var paint = new Paint
            {
                Fill = Fill,
                Stroke = Stroke,
                IsAntialiased = IsAntialiased,
                Opacity = Opacity,
                StrokeThickness = StrokeThickness,
                DashPattern = DashPattern
            };

            e.DrawLine(Point1, Point2, paint);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}