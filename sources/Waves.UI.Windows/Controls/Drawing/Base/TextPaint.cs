using Waves.UI.Windows.Controls.Drawing.Base.Interfaces;

namespace Waves.UI.Windows.Controls.Drawing.Base
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