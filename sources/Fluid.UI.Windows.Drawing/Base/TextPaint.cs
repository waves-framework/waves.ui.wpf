using Fluid.UI.Windows.Drawing.Base.Interfaces;

namespace Fluid.UI.Windows.Drawing.Base
{
    /// <summary>
    /// Base text paint.
    /// </summary>
    public class TextPaint : Paint, ITextPaint
    {
        /// <inheritdoc />
        public ITextStyle TextStyle { get; set; } = new TextStyle();
    }
}