using System;
using Fluid.Core.Base;

namespace Fluid.UI.Windows.Drawing.Base.Interfaces
{
    /// <summary>
    /// Interface for paint instances.
    /// </summary>
    public interface IPaint : IDisposable
    {
        /// <summary>
        /// Gets or sets whether paint is antialiased.
        /// </summary>
        bool IsAntialiased { get; set; }

        /// <summary>
        /// Gets or sets color.
        /// </summary>
        Color Fill { get; set; }

        /// <summary>
        /// Gets or sets stroke color.
        /// </summary>
        Color Stroke { get; set; }

        /// <summary>
        /// Gets or sets opacity.
        /// </summary>
        float Opacity { get; set; }

        /// <summary>
        /// Gets or sets stroke thickness.
        /// </summary>
        float StrokeThickness { get; set; }

        /// <summary>
        /// Gets or sets dash pattern.
        /// </summary>
        float[] DashPattern { get; set; }
    }
}