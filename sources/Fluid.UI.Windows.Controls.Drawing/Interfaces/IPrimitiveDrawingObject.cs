using Fluid.Core.Base;

namespace Fluid.UI.Windows.Controls.Drawing.Interfaces
{
    /// <summary>
    /// Interface of primitive drawing object.
    /// </summary>
    public interface IPrimitiveDrawingObject
    {
        /// <summary>
        /// Gets or sets height.
        /// </summary>
        float Height { get; set; }

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        float Width { get; set; }

        /// <summary>
        /// Gets or sets stroke thickness.
        /// </summary>
        float StrokeThickness { get; set; }

        /// <summary>
        /// Gets or sets fill.
        /// </summary>
        Color Fill { get; set; }

        /// <summary>
        /// Gets or sets stroke.
        /// </summary>
        Color Stroke { get; set; }

        /// <summary>
        /// Gets or sets location.
        /// </summary>
        Point Location { get; set; }
    }
}