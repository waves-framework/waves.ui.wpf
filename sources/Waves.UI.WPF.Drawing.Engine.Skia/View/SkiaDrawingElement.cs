using System;
using System.Collections.Generic;
using Waves.Core.Base;
using Waves.UI.WPF.Drawing.Engine.Skia.Extensions;
using SkiaSharp;
using Waves.UI.Drawing.Base.Interfaces;

namespace Waves.UI.WPF.Drawing.Engine.Skia.View
{
    /// <summary>
    ///     Skia drawing element.
    /// </summary>
    public class SkiaDrawingElement : WavesObject, IDrawingElement
    {
        /// <summary>
        ///     Gets or sets SKSurface.
        /// </summary>
        public SKSurface Surface { get; set; }

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF Skia Drawing Object";

        /// <inheritdoc />
        public override void Dispose()
        {
            Surface?.Dispose();
        }
        
        /// <inheritdoc />
        public void Draw(object element, ICollection<IDrawingObject> drawingObjects)
        {
            var surface = element as SKSurface;
            if (surface == null) return;

            if (Surface == null)
                Surface = surface;

            if (Surface.Handle == IntPtr.Zero)
                Surface = surface;

            Surface.Canvas.Clear(SKColor.Empty);

            foreach (var obj in drawingObjects)
                obj.Draw(this);
        }

        /// <inheritdoc />
        public void DrawEllipse(WavesPoint location, float radius, IPaint paint)
        {
            using (var skPaint = new SKPaint
            {
                Color = paint.Fill.ToSkColor(paint.Opacity),
                IsAntialias = paint.IsAntialiased
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
                IsStroke = true,
            })
            {
                Surface.Canvas.DrawCircle(location.X, location.Y, radius, skPaint);
            }
        }

        /// <inheritdoc />
        public void DrawLine(WavesPoint point1, WavesPoint point2, IPaint paint)
        {
            using var skPaint = new SKPaint
            {
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
        public void DrawRectangle(WavesPoint location, WavesSize size, IPaint paint, float cornerRadius = 0)
        {
            using (var skPaint = new SKPaint
            {
                Color = paint.Fill.ToSkColor(paint.Opacity),
                IsAntialias = paint.IsAntialiased
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
        public void DrawText(WavesPoint location, string text, ITextPaint paint)
        {
            using var skPaint = GetSkiaTextPaint(paint);

            Surface.Canvas.DrawText(text, location.ToSkPoint(), skPaint);
        }

        /// <inheritdoc />
        public WavesSize MeasureText(string text, ITextPaint paint)
        {
            using var skPaint = GetSkiaTextPaint(paint);

            var bounds = new SKRect();
            skPaint.MeasureText(text, ref bounds);

            return new WavesSize(bounds.Width, bounds.Height);
        }

        /// <summary>
        ///     Gets Skia text paint.
        /// </summary>
        /// <param name="paint">Waves's paint.</param>
        /// <returns>Skia text paint.</returns>
        private SKPaint GetSkiaTextPaint(ITextPaint paint)
        {
            return new SKPaint
            {
                TextSize = paint.TextStyle.FontSize,
                Color = paint.Fill.ToSkColor(),
                IsStroke = false,
                SubpixelText = true,
                IsAntialias = true,
                TextAlign = paint.TextStyle.Alignment.ToSkTextAlign(),
                Typeface = SKTypeface.FromFamilyName(paint.TextStyle.FontFamily)
            };
        }
    }
}