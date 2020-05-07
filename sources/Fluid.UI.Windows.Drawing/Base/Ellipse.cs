using Fluid.UI.Windows.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Drawing.Base
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

            using (var paint = new Paint {Fill = Fill, IsAntialiased = IsAntialiased, Opacity = Opacity})
            {
                e.DrawCircle(Location, Radius, paint);
            }

            if (!(StrokeThickness > 0)) return;

            using (var paint = new Paint
                {IsAntialiased = IsAntialiased, Opacity = Opacity, Stroke = Stroke, StrokeThickness = StrokeThickness})
            {
                e.DrawCircle(Location, Radius, paint);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}