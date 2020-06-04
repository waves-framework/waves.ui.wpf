using System;
using Waves.Core.Base;
using SkiaSharp;
using Waves.UI.Drawing.Base.Enums;

namespace Waves.UI.Windows.Drawing.Engine.Skia.Extensions
{
    /// <summary>
    /// Skia extensions.
    /// </summary>
    public static class Skia
    {
        /// <summary>
        ///     Converts color to Skia color.
        /// </summary>
        /// <returns>Skia color.</returns>
        public static SKColor ToSkColor(this Color color)
        {
            return new SKColor(color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Converts color to Skia color with current opacity.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <param name="opacity">Opacity.</param>
        /// <returns></returns>
        public static SKColor ToSkColor(this Color color, float opacity)
        {
            var a = Convert.ToByte(opacity * color.A);
            return new SKColor(color.R, color.G, color.B, a);
        }

        /// <summary>
        /// Converts point to Skia point.
        /// </summary>
        /// <param name="point">Point.</param>
        /// <returns>Skia point.</returns>
        public static SKPoint ToSkPoint(this Point point)
        {
            return new SKPoint(point.X, point.Y);
        }

        /// <summary>
        /// Converts text alignment to SKTextAlign.
        /// </summary>
        /// <param name="alignment">Text alignment.</param>
        /// <returns>SKTextAlign</returns>
        public static SKTextAlign ToSkTextAlign(this TextAlignment alignment)
        {
            switch (alignment)
            {
                case TextAlignment.Left:
                    return SKTextAlign.Left;
                case TextAlignment.Right:
                    return SKTextAlign.Right;
                case TextAlignment.Center:
                    return SKTextAlign.Center;
                default:
                    return SKTextAlign.Left;
            }
        }
    }
}