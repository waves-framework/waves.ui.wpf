using System;
using Fluid.Core.Base;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Utils
{
    public class Resampling
    {
        /// <summary>
        /// Downsamples data with Largest Triangle Three Buckets algorithm.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <param name="threshold">Number of points.</param>
        /// <returns>Downsampled data.</returns>
        public static Point[] LargestTriangleThreeBucketsDownsampling(Point[] input, int threshold)
        {
            if (threshold == 0) return new Point[0];

            var output = new Point[threshold];

            var dataLength = input.Length;
            if (threshold >= dataLength || threshold == 0)
                return input;

            var every = (double)(dataLength - 2) / (threshold - 2);

            var a = 0;
            var maxAreaPoint = new Point(0, 0);
            var nextA = 0;

            output[0] = input[a];

            for (var i = 0; i < threshold - 2; i++)
            {
                var avgX = 0.0d;
                var avgY = 0.0d;
                var avgRangeStart = (int)(Math.Floor((i + 1) * every) + 1);
                var avgRangeEnd = (int)(Math.Floor((i + 2) * every) + 1);
                avgRangeEnd = avgRangeEnd < dataLength ? avgRangeEnd : dataLength;

                var avgRangeLength = avgRangeEnd - avgRangeStart;

                for (; avgRangeStart < avgRangeEnd; avgRangeStart++)
                {
                    avgX += input[avgRangeStart].X;
                    avgY += input[avgRangeStart].Y;
                }

                avgX /= avgRangeLength;
                avgY /= avgRangeLength;

                // Get the range for this bucket
                var rangeOffs = (int)(Math.Floor((i + 0) * every) + 1);
                var rangeTo = (int)(Math.Floor((i + 1) * every) + 1);

                // Point a
                var pointAx = input[a].X;
                var pointAy = input[a].Y;
                var maxArea = -1.0d;

                for (; rangeOffs < rangeTo; rangeOffs++)
                {
                    // Calculate triangle area over three buckets
                    var area = Math.Abs((pointAx - avgX) * (input[rangeOffs].Y - pointAy) -
                                        (pointAx - input[rangeOffs].X) * (avgY - pointAy)
                               ) * 0.5;
                    if (area > maxArea)
                    {
                        maxArea = area;
                        maxAreaPoint = input[rangeOffs];
                        nextA = rangeOffs; // Next a is this b
                    }
                }

                output[i + 1] = maxAreaPoint; // Pick this point from the bucket
                a = nextA; // This a is the next a (chosen b)
            }

            output[threshold - 1] = input[dataLength - 1]; // Always add last

            return output;
        }

        /// <summary>
        /// Spline upsampling.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <param name="threshold">Number of points.</param>
        /// <returns>Upsampled data.</returns>
        public static Point[] SplineUpsampling(Point[] input, int threshold)
        {
            return input;
        }
    }
}