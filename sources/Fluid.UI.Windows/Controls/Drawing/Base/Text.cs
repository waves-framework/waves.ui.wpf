using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Base
{
    /// <summary>
    /// Text.
    /// </summary>
    public class Text : DrawingObject
    {
        /// <inheritdoc />
        public override string Name { get; set; } = "Text";

        /// <summary>
        /// Gets or sets text style.
        /// </summary>
        public TextStyle Style { get; set; }

        /// <summary>
        /// Gets or sets text value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets text location.
        /// </summary>
        public Point Location { get; set; } = new Point(0, 0);

        /// <inheritdoc />
        public override void Draw(IDrawingElement e)
        {
            if (Style == null) return;
            if (!IsVisible) return;

            using var paint = new TextPaint
            {
                Fill = Fill, 
                IsAntialiased = IsAntialiased, 
                Opacity = Opacity, 
                TextStyle = Style
            };

            e.DrawText(Location, Value, paint);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}