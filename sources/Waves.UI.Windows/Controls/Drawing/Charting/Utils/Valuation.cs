using Waves.Core.Base;

namespace Waves.UI.Windows.Controls.Drawing.Charting.Utils
{
    /// <summary>
    ///     Valuation utils.
    /// </summary>
    public class Valuation
    {
        /// <summary>
        ///     Normalizing of a point along the X axis.
        /// </summary>
        /// <param name="input">Input value.</param>
        /// <param name="width">Chart width.</param>
        /// <param name="min">Chart's minimum bound value along the X axis.</param>
        /// <param name="max">Chart's maximum bound value along the X axis.</param>
        /// <returns>Normalized value.</returns>
        public static float NormalizePointX2D(float input, float width, float min, float max)
        {
            return (input - min) * width / (max - min);
        }

        /// <summary>
        ///     Denormalizing of a point along the X axis.
        /// </summary>
        /// <param name="input">Input value.</param>
        /// <param name="width">Chart width.</param>
        /// <param name="min">Chart's minimum bound value along the X axis.</param>
        /// <param name="max">Chart's maximum bound value along the X axis.</param>
        /// <returns>Denormalized value.</returns>
        public static float DenormalizePointX2D(float input, float width, float min, float max)
        {
            return input * (max - min) / width + min;
        }

        /// <summary>
        ///     Normalizing of a point along the Y axis.
        /// </summary>
        /// <param name="input">Input value.</param>
        /// <param name="height">Chart width.</param>
        /// <param name="min">Chart's minimum bound value along the Y axis.</param>
        /// <param name="max">Chart's maximum bound value along the Y axis.</param>
        /// <returns>Normalized value.</returns>
        public static float NormalizePointY2D(float input, float height, float min, float max)
        {
            return height - (input - min) * height / (max - min);
        }

        /// <summary>
        ///     Denormalizing of a point along the Y axis.
        /// </summary>
        /// <param name="input">Input value.</param>
        /// <param name="height">Chart width.</param>
        /// <param name="min">Chart's minimum bound value along the Y axis.</param>
        /// <param name="max">Chart's maximum bound value along the Y axis.</param>
        /// <returns>Denormalized value.</returns>
        public static float DenormalizePointY2D(float input, float height, float min, float max)
        {
            return (height - input) * (max - min) / height + min;
        }

        /// <summary>
        ///     Normalizing of a point.
        /// </summary>
        /// <param name="input">Input point.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <param name="xMin">Chart's minimum bound value along the X axis.</param>
        /// <param name="yMin">Chart's maximum bound value along the X axis.</param>
        /// <param name="xMax">Chart's minimum bound value along the Y axis.</param>
        /// <param name="yMax">Chart's maximum bound value along the Y axis.</param>
        /// <returns>Normalized point.</returns>
        public static Point NormalizePoint(Point input, float width, float height, float xMin, float yMin, float xMax,
            float yMax)
        {
            return new Point(NormalizePointX2D(input.X, width, xMin, xMax),
                NormalizePointY2D(input.Y, height, yMin, yMax));
        }

        /// <summary>
        ///     Normalizing of a point.
        /// </summary>
        /// <param name="x">X value of point.</param>
        /// <param name="y">Y value of point.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <param name="xMin">Chart's minimum bound value along the X axis.</param>
        /// <param name="yMin">Chart's maximum bound value along the X axis.</param>
        /// <param name="xMax">Chart's minimum bound value along the Y axis.</param>
        /// <param name="yMax">Chart's maximum bound value along the Y axis.</param>
        /// <returns>Normalized point.</returns>
        public static Point NormalizePoint(float x, float y, float width, float height, float xMin, float yMin,
            float xMax, float yMax)
        {
            return new Point(NormalizePointX2D(x, width, xMin, xMax),
                NormalizePointY2D(y, height, yMin, yMax));
        }

        /// <summary>
        ///     Denormalizing of a point.
        /// </summary>
        /// <param name="input">Input point.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <param name="xMin">Chart's minimum bound value along the X axis.</param>
        /// <param name="yMin">Chart's maximum bound value along the X axis.</param>
        /// <param name="xMax">Chart's minimum bound value along the Y axis.</param>
        /// <param name="yMax">Chart's maximum bound value along the Y axis.</param>
        /// <returns>Denormalized point.</returns>
        public static Point DenormalizePoint(Point input, float width, float height, float xMin, float yMin, float xMax,
            float yMax)
        {
            return new Point(DenormalizePointX2D(input.X, width, xMin, xMax),
                DenormalizePointY2D(input.Y, height, yMin, yMax));
        }

        /// <summary>
        ///     Denormalizing of a point.
        /// </summary>
        /// <param name="x">X value of point.</param>
        /// <param name="y">Y value of point.</param>
        /// <param name="width">Chart's width.</param>
        /// <param name="height">Chart's height.</param>
        /// <param name="xMin">Chart's minimum bound value along the X axis.</param>
        /// <param name="yMin">Chart's maximum bound value along the X axis.</param>
        /// <param name="xMax">Chart's minimum bound value along the Y axis.</param>
        /// <param name="yMax">Chart's maximum bound value along the Y axis.</param>
        /// <returns>Denormalized point.</returns>
        public static Point DenormalizePoint(float x, float y, float width, float height, float xMin, float yMin,
            float xMax, float yMax)
        {
            return new Point(DenormalizePointX2D(x, width, xMin, xMax),
                DenormalizePointY2D(y, height, yMin, yMax));
        }
    }
}