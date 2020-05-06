using Fluid.Core.Base;
using Fluid.UI.Windows.Drawing.Extensions;
using SkiaSharp;

namespace Fluid.UI.Windows.Drawing.Base.Primitives
{
    /// <summary>
    /// Text.
    /// </summary>
    public class Text : DrawingObject
    {
        /// <inheritdoc />
        public override string Name { get; set; } = "Text";

        /// <inheritdoc />
        public override Size Size
        {
            get
            {
                if (Style == null) return new Size(0, 0);

                using (var paint = new SKPaint
                {
                    TextSize = Style.FontSize,
                    Color = Style.Color.ToSkColor(),
                    IsStroke = false,
                    SubpixelText = true,
                    IsAntialias = IsAntialiased,
                    TextAlign = Style.Alignment.ToSkTextAlign(),
                })
                {
                    paint.Typeface = SKTypeface.FromFamilyName(Style.FontName);

                    var bounds = new SKRect();
                    paint.MeasureText(Value, ref bounds);

                    return new Size(bounds.Width, bounds.Height);
                }
            }
        }

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
        public override void Draw(SKCanvas canvas)
        {
            if (Style == null) return;
            if (!IsVisible) return;

            using (var paint = new SKPaint
            {
                TextSize = Style.FontSize,
                Color = Style.Color.ToSkColor(),
                IsStroke = false,
                SubpixelText = true,
                IsAntialias = true,
                TextAlign = Style.Alignment.ToSkTextAlign(),
            })
            {
                paint.Typeface = SKTypeface.FromFamilyName(Style.FontName);
                canvas.DrawText(Value, Location.ToSkPoint(), paint);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}