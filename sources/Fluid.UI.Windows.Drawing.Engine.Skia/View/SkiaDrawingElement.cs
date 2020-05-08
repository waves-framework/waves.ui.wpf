using System;
using System.Windows;
using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Engine.Skia.Extensions;
using SkiaSharp;
using Point = Fluid.Core.Base.Point;
using Size = Fluid.Core.Base.Size;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.View
{
    /// <summary>
    /// Skia drawing element.
    /// </summary>
    public class SkiaDrawingElement : IDrawingElement
    {
        /// <summary>
        /// Creates new instance of <see cref="SkiaDrawingElement"/>
        /// </summary>
        /// <param name="surface">Surface.</param>
        public SkiaDrawingElement(SKSurface surface)
        {
            Surface = surface;
        }

        /// <summary>
        /// Gets or sets SKSurface.
        /// </summary>
        public SKSurface Surface { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {
            Surface?.Dispose();
        }

        /// <inheritdoc />
        public void DrawEllipse(Point location, float radius, IPaint paint)
        {
            using (var skPaint = new SKPaint
            {
                Color = paint.Fill.ToSkColor(paint.Opacity),
                IsAntialias = paint.IsAntialiased,
            })
            {
                Surface.Canvas.DrawCircle(location.X, location.Y, radius, skPaint);
            }

            if (!(paint.StrokeThickness > 0)) return;

            using (var skPaint = new SKPaint
            {
                Color = paint.Stroke.ToSkColor(paint.Opacity),
                IsAntialias = paint.IsAntialiased,
                StrokeWidth = paint.StrokeThickness,
                IsStroke = true
            })
            {
                Surface.Canvas.DrawCircle(location.X, location.Y, radius, skPaint);
            }
        }

        /// <inheritdoc />
        public void DrawLine(Point point1, Point point2, IPaint paint)
        {
            using var skPaint = new SKPaint{ 
                Color = paint.Fill.ToSkColor(paint.Opacity), 
                StrokeWidth = paint.StrokeThickness, 
                IsAntialias = paint.IsAntialiased,
                IsStroke = Math.Abs(paint.StrokeThickness) > float.Epsilon
            };

            if (paint.DashPattern != null)
            {
                var dashEffect = SKPathEffect.CreateDash(paint.DashPattern, 0);
                skPaint.PathEffect = skPaint.PathEffect != null
                    ? SKPathEffect.CreateCompose(dashEffect, skPaint.PathEffect)
                    : dashEffect;
            }

            Surface.Canvas.DrawLine(point1.ToSkPoint(), point2.ToSkPoint(), skPaint);
        }

        /// <inheritdoc />
        public void DrawRectangle(Point location, Size size, IPaint paint, float cornerRadius = 0)
        {
            using (var skPaint = new SKPaint
            {
                Color = paint.Fill.ToSkColor(paint.Opacity),
                IsAntialias = paint.IsAntialiased,
            })
            {
                Surface.Canvas.DrawRoundRect(location.X, location.Y, size.Width, size.Height,
                    cornerRadius, cornerRadius, skPaint);
            }

            if (!(paint.StrokeThickness > 0)) return;

            using (var skPaint = new SKPaint
            {
                Color = paint.Stroke.ToSkColor(paint.Opacity),
                IsAntialias = paint.IsAntialiased,
                StrokeWidth = paint.StrokeThickness,
                IsStroke = true
            })
            {
                Surface.Canvas.DrawRoundRect(location.X, location.Y, size.Width, size.Height,
                    cornerRadius, cornerRadius, skPaint);
            }
        }

        /// <inheritdoc />
        public void DrawText(Point location, string text, ITextPaint paint)
        {
            using var skPaint = new SKPaint
            {
                TextSize = paint.TextStyle.FontSize,
                Color = paint.Fill.ToSkColor(),
                IsStroke = false,
                SubpixelText = true,
                IsAntialias = true,
                TextAlign = paint.TextStyle.Alignment.ToSkTextAlign(),
                Typeface = SKTypeface.FromFamilyName(paint.TextStyle.FontFamily)
            };

            Surface.Canvas.DrawText(text, location.ToSkPoint(), skPaint);
        }
    }
}