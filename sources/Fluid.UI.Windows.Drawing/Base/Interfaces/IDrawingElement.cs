using System;
using Fluid.Core.Base;

namespace Fluid.UI.Windows.Drawing.Base.Interfaces
{
    /// <summary>
    /// Interface for drawing element.
    /// </summary>
    public interface IDrawingElement : IDisposable
    {
        /// <summary>
        /// Draws circle.
        /// </summary>
        /// <param name="location">Location.</param>
        /// <param name="radius">Radius.</param>
        /// <param name="paint">Paint.</param>
        void DrawCircle(Point location, float radius, IPaint paint);

        /// <summary>
        /// Draws line.
        /// </summary>
        /// <param name="point1">Point 1.</param>
        /// <param name="point2">Point 2.</param>
        /// <param name="paint">Paint.</param>
        void DrawLine(Point point1, Point point2, IPaint paint);
    }
}