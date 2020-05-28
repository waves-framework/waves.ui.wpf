using Waves.UI.Windows.Controls.Drawing.Charting.Base.Enums;

namespace Waves.UI.Windows.Controls.Drawing.Charting.Base.Interfaces
{
    /// <summary>
    /// Interface for axis tick.
    /// </summary>
    public interface IAxisTick
    {
        /// <summary>
        ///     Gets or sets whether tick is visible.
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        ///     Gets or sets tick's value.
        /// </summary>
        float Value { get; set; }

        /// <summary>
        ///     Gets or sets tick's description / tooltip.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets tick type.
        /// </summary>
        AxisTickType Type { get; set; }

        /// <summary>
        ///     Gets or sets tick's orientation.
        /// </summary>
        AxisTickOrientation Orientation { get; set; }
    }
}