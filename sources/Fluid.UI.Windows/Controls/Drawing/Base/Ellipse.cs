using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Base
{
    /// <summary>
    ///     Ellipse.
    /// </summary>
    public class Ellipse : ShapeDrawingObject
    {
        /// <inheritdoc />
        public override string Name { get; set; } = "Ellipse";

        /// <summary>
        ///     Gets or sets ellipse radius.
        /// </summary>
        public float Radius { get; set; }

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
                StrokeThickness = StrokeThickness
            };

            e.DrawEllipse(Location, Radius, paint);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}