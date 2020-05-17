using System;
using System.Collections.Generic;
using System.Globalization;
using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Enums;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Utils
{
    /// <summary>
    /// Axis ticks utils.
    /// </summary>
    public static class Ticks
    {
        /// <summary>
        /// Generates axis tick list.
        /// </summary>
        /// <param name="ticks">Ticks list.</param>
        /// <param name="min">Axis bound minimum.</param>
        /// <param name="max">Axis bound maximum.</param>
        /// <param name="primaryTicksCount">Primary ticks count.</param>
        /// <param name="additionalTicksCount">Additional ticks count.</param>
        /// <param name="orientation">Axis tick orientation.</param>
        public static void GenerateAxisTicks(this List<AxisTick> ticks, float min, float max, int primaryTicksCount,
            int additionalTicksCount, AxisTickOrientation orientation)
        {
            var e = (int) Math.Round(Math.Log10(max - min));

            if (e == int.MinValue) return;

            var m = (float) Math.Pow(10, e);
            var b = Math.Abs(e) + 1;
            var tickStep = m / primaryTicksCount;
            var additionalTickStep = tickStep / additionalTicksCount;
            if (!(Math.Abs(tickStep) > 0)) return;

            var start = Math.Round(min / tickStep) * tickStep;

            for (var i = start; i <= max; i += tickStep)
            {
                for (var j = i + additionalTickStep; j <= i + tickStep - additionalTickStep; j += additionalTickStep)
                {
                    if (j > max) continue;

                    if (Math.Abs(j - min) < float.Epsilon || Math.Abs(j - max) < float.Epsilon) continue;

                    ticks.Add(new AxisTick
                    {
                        Description = j.ToString(CultureInfo.InvariantCulture),
                        Value = Convert.ToSingle(j),
                        IsVisible = true,
                        Orientation = orientation,
                        Type = AxisTickType.Additional
                    });
                }

                if (i > max) continue;

                if (Math.Abs(i) > 0)
                {
                    if (Math.Abs(i - min) < float.Epsilon || Math.Abs(i - max) < float.Epsilon) continue;

                    var description = i.ToString(CultureInfo.InvariantCulture);
                    if (b < 15)
                        description = Math.Round(i, b).ToString(CultureInfo.InvariantCulture);

                    ticks.Add(new AxisTick
                    {
                        Description = description,
                        Value = Convert.ToSingle(i),
                        IsVisible = true,
                        Orientation = orientation,
                        Type = AxisTickType.Primary
                    });
                }
            }

            ticks.Reverse();

            if (min < 0 && max > 0)
                ticks.Add(new AxisTick
                {
                    Description = 0.ToString(CultureInfo.InvariantCulture),
                    Value = 0,
                    IsVisible = true,
                    Orientation = orientation,
                    Type = AxisTickType.Zero
                });
        }

        /// <summary>
        /// Generates X axis tick line.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="strokeThickness">Stroke thickness.</param>
        /// <param name="stroke">Stroke color.</param>
        /// <param name="dashArray">Dash array / pattern.</param>
        /// <param name="opacity">Opacity.</param>
        /// <param name="xMin">Minimum bound of X axis.</param>
        /// <param name="xMax">Maximum bound of X axis</param>
        /// <param name="width">Chart width.</param>
        /// <param name="height">Chart height.</param>
        /// <returns>Returns line.</returns>
        public static Line GetXAxisTickLine(float value, float strokeThickness, Color stroke, float[] dashArray, float opacity,
            float xMin, float xMax, float width, float height)
        {
            return new Line
            {
                Stroke = stroke,
                Fill = stroke,
                DashPattern = dashArray,
                IsAntialiased = true,
                IsVisible = true,
                Opacity = opacity,
                StrokeThickness = strokeThickness,
                Point1 = new Point(Valuation.NormalizePointX2D(value, width, xMin, xMax), 0),
                Point2 = new Point(Valuation.NormalizePointX2D(value, width, xMin, xMax), height)
            };
        }

        /// <summary>
        /// Generates Y axis tick line.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="strokeThickness">Stroke thickness.</param>
        /// <param name="stroke">Stroke color.</param>
        /// <param name="dashArray">Dash array / pattern.</param>
        /// <param name="opacity">Opacity.</param>
        /// <param name="yMin">Minimum bound of Y axis.</param>
        /// <param name="yMax">Maximum bound of Y axis</param>
        /// <param name="width">Chart width.</param>
        /// <param name="height">Chart height.</param>
        /// <returns>Returns line.</returns>
        public static Line GetYAxisTickLine(float value, float strokeThickness, Color stroke, float[] dashArray, float opacity,
            float yMin, float yMax, float width, float height)
        {
            return new Line
            {
                Stroke = stroke,
                Fill = stroke,
                DashPattern = dashArray,
                IsAntialiased = true,
                IsVisible = true,
                Opacity = opacity,
                StrokeThickness = strokeThickness,
                Point1 = new Point(0, Valuation.NormalizePointY2D(value, height, yMin, yMax)),
                Point2 = new Point(width, Valuation.NormalizePointY2D(value, height, yMin, yMax))
            };
        }
    }
}