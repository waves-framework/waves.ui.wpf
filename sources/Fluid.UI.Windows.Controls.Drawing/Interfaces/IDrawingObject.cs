using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using SkiaSharp;

namespace Fluid.UI.Windows.Controls.Drawing.Interfaces
{
    /// <summary>
    /// Interface of drawing object.
    /// </summary>
    public interface IDrawingObject : IObject
    {
        /// <summary>
        ///     Gets whether drawing object is antialiased.
        /// </summary>
        bool IsAntialiased { get; set; }

        /// <summary>
        ///     Gets whether drawing object is visible.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets object's opacity.
        /// </summary>
        float Opacity { get; set; }

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
        /// Gets size of object.
        /// </summary>
        Size Size { get; }

        /// <summary>
        ///     Draw object in current canvas.
        /// </summary>
        /// <param name="canvas">Canvas.</param>
        void Draw(SKCanvas canvas);
    }
}