using Fluid.Core.Base;
using Fluid.UI.Windows.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Drawing.Base
{
    /// <summary>
    /// Base paint.
    /// </summary>
    public class Paint : IPaint
    {
        /// <inheritdoc />
        public bool IsAntialiased { get; set; } = true;

        /// <inheritdoc />
        public Color Fill { get; set; } = Color.Black;

        /// <inheritdoc />
        public Color Stroke { get; set; } = Color.Gray;

        /// <inheritdoc />
        public float Opacity { get; set; }

        /// <inheritdoc />
        public float StrokeThickness { get; set; } = 1;

        /// <inheritdoc />
        public float[] DashPattern { get; set; } = { 0, 0, 0, 0 };

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}