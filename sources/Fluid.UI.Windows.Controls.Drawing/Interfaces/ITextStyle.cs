using Fluid.Core.Base;

namespace Fluid.UI.Windows.Controls.Drawing.Interfaces
{
    /// <summary>
    /// Text style interface.
    /// </summary>
    public interface ITextStyle
    {
        /// <summary>
        /// Gets or sets font size.
        /// </summary>
        float FontSize { get; set; }

        /// <summary>
        /// Gets or sets text color.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Gets or sets font name.
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        /// Gets or sets font weight.
        /// </summary>
        int Weight { get; set; }

        /// <summary>
        /// Gets or sets text alignment.
        /// </summary>
        TextAlignment Alignment { get; set; }
    }
}