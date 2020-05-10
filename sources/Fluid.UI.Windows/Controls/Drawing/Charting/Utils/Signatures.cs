using System;
using System.Globalization;
using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Utils
{
    /// <summary>
    ///     Axis signatures utils.
    /// </summary>
    public static class Signatures
    {
        /// <summary>
        ///     Gets axis signatures along the X axis.
        /// </summary>
        /// <param name="value">Signature value.</param>
        /// <param name="description">Signature description.</param>
        /// <param name="fill">Text color.</param>
        /// <param name="style">Text style.</param>
        /// <param name="opacity">Opacity.</param>
        /// <param name="xMin">Chart's minimum bound value along the X axis.</param>
        /// <param name="xMax">Chart's maximum bound value along the X axis.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <returns>Returns text.</returns>
        public static Text GetXAxisSignature(float value, string description, Color fill, TextStyle style, float opacity,
            float xMin, float xMax,
            float width, float height)
        {
            return new Text
            {
                Location = new Point(Valuation.NormalizePointX2D(value, width, xMin, xMax), height - 12),
                Style = style,
                Value = description,
                IsVisible = true,
                IsAntialiased = true,
                Fill = fill
            };
        }

        /// <summary>
        ///     Gets axis signatures along the X axis.
        /// </summary>
        /// <param name="value">Signature value.</param>
        /// <param name="description">Signature description.</param>
        /// <param name="paint">Text color.</param>
        /// <param name="xMin">Chart's minimum bound value along the X axis.</param>
        /// <param name="xMax">Chart's maximum bound value along the X axis.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <returns>Returns text.</returns>
        public static Text GetXAxisSignature(float value, string description, ITextPaint paint,
            float xMin, float xMax,
            float width, float height)
        {
            return new Text
            {
                Location = new Point(Valuation.NormalizePointX2D(value, width, xMin, xMax), height - 12),
                Style = paint.TextStyle,
                Value = description,
                IsVisible = true,
                IsAntialiased = true,
                Fill = paint.Fill,
                Opacity = paint.Opacity
            };
        }

        /// <summary>
        ///     Gets axis signatures along the Y axis.
        /// </summary>
        /// <param name="value">Signature value.</param>
        /// <param name="description">Signature description.</param>
        /// <param name="fill">Text color.</param>
        /// <param name="style">Text style.</param>
        /// <param name="opacity">Opacity.</param>
        /// <param name="yMin">Chart's minimum bound value along the Y axis.</param>
        /// <param name="yMax">Chart's maximum bound value along the Y axis.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <returns>Returns text.</returns>
        public static Text GetYAxisSignature(float value, string description, Color fill, TextStyle style, float opacity,
            float yMin, float yMax,
            float width, float height)
        {
            return new Text
            {
                Location = new Point(12, Valuation.NormalizePointY2D(value, height, yMin, yMax)),
                Style = style,
                Value = description,
                IsVisible = true,
                IsAntialiased = true,
                Fill = fill
            };
        }

        /// <summary>
        ///     Gets axis signatures along the Y axis.
        /// </summary>
        /// <param name="value">Signature value.</param>
        /// <param name="description">Signature description.</param>
        /// <param name="paint">Text paint.</param>
        /// <param name="yMin">Chart's minimum bound value along the Y axis.</param>
        /// <param name="yMax">Chart's maximum bound value along the Y axis.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <returns>Returns text.</returns>
        public static Text GetYAxisSignature(float value, string description, ITextPaint paint,
            float yMin, float yMax,
            float width, float height)
        {
            return new Text
            {
                Location = new Point(12, Valuation.NormalizePointY2D(value, height, yMin, yMax)),
                Style = paint.TextStyle,
                Value = description,
                IsVisible = true,
                IsAntialiased = true,
                Fill = paint.Fill,
                Opacity = paint.Opacity
            };
        }

        /// <summary>
        ///     Gets signature's backing rectangle along the X axis.
        /// </summary>
        /// <param name="value">Signature value.</param>
        /// <param name="fill">Rectangle's fill.</param>
        /// <param name="stroke">Rectangle's stroke.</param>
        /// <param name="strokeThickness">Rectangle's stroke thickness.</param>
        /// <param name="opacity">Rectangle's opacity.</param>
        /// <param name="cornerRadius">Rectangle's corner radius.</param>
        /// <param name="innerTextWidth">Inner text width.</param>
        /// <param name="innerTextHeight">Inner text height.</param>
        /// <param name="xMin">Chart's minimum bound value along the X axis.</param>
        /// <param name="xMax">Chart's maximum bound value along the X axis.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <returns>Signature's backing rectangle.</returns>
        public static Rectangle GetXAxisSignatureRectangle(float value, Color fill,
            Color stroke, float strokeThickness, float opacity, float cornerRadius, float innerTextWidth,
            float innerTextHeight, float xMin, float xMax,
            float width, float height)
        {
            return new Rectangle
            {
                Location = new Point(Valuation.NormalizePointX2D(value, width, xMin, xMax) - innerTextWidth / 2 - 6,
                    height - innerTextHeight - 12 - 6),
                CornerRadius = cornerRadius,
                Opacity = opacity,
                Fill = fill,
                Stroke = stroke,
                StrokeThickness = strokeThickness,
                Width = innerTextWidth + 12,
                Height = innerTextHeight + 12,
                IsVisible = true,
                IsAntialiased = true
            };
        }

        /// <summary>
        ///     Gets signature's backing rectangle along the Y axis.
        /// </summary>
        /// <param name="value">Signature value.</param>
        /// <param name="fill">Rectangle's fill.</param>
        /// <param name="stroke">Rectangle's stroke.</param>
        /// <param name="strokeThickness">Rectangle's stroke thickness.</param>
        /// <param name="opacity">Rectangle's opacity.</param>
        /// <param name="cornerRadius">Rectangle's corner radius.</param>
        /// <param name="innerTextWidth">Inner text width.</param>
        /// <param name="innerTextHeight">Inner text height.</param>
        /// <param name="yMin">Chart's minimum bound value along the Y axis.</param>
        /// <param name="yMax">Chart's maximum bound value along the Y axis.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <returns>Signature's backing rectangle.</returns>
        public static Rectangle GetYAxisSignatureRectangle(float value, Color fill,
            Color stroke, float strokeThickness, float opacity, float cornerRadius, float innerTextWidth,
            float innerTextHeight, float yMin, float yMax,
            float width, float height)
        {
            return new Rectangle
            {
                Location = new Point(6,
                    Valuation.NormalizePointY2D(value, height, yMin, yMax) - innerTextHeight / 2 - 6),
                CornerRadius = cornerRadius,
                Fill = fill,
                Stroke = stroke,
                StrokeThickness = strokeThickness,
                Width = innerTextWidth + 12,
                Height = innerTextHeight + 12,
                IsVisible = true,
                IsAntialiased = true
            };
        }

        /// <summary>
        ///     Optimizes value for view.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>Optimized value.</returns>
        public static string OptimizeNumericString(float value)
        {
            var numbers = value.ToString(CultureInfo.InvariantCulture).Split('.');

            if (numbers.Length > 1)
            {
                if (numbers[1].Length >= 0 && numbers.Length < 12)
                    return Math.Round(value, 3).ToString(CultureInfo.InvariantCulture);

                if (numbers[1].Length >= 12 && numbers.Length < 24)
                    return Math.Round(value, 6).ToString(CultureInfo.InvariantCulture);
            }

            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}