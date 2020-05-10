using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Enums;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Base
{
    /// <summary>
    /// Axis tick.
    /// </summary>
    public class AxisTick : IAxisTick
    {
        /// <inheritdoc />
        public bool IsVisible { get; set; }

        /// <inheritdoc />
        public float Value { get; set; }

        /// <inheritdoc />
        public string Description { get; set; }

        /// <inheritdoc />
        public AxisTickType Type { get; set; }

        /// <inheritdoc />
        public AxisTickOrientation Orientation { get; set; }
    }
}