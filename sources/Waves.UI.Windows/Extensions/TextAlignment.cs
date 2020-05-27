namespace Waves.UI.Windows.Extensions
{
    /// <summary>
    /// Text alignment.
    /// </summary>
    public static class TextAlignment
    {
        /// <summary>
        /// Converts Waves text alignment to system text alignment.
        /// </summary>
        /// <param name="alignment">Waves text alignment.</param>
        /// <returns>System text alignment.</returns>
        public static System.Windows.TextAlignment ToSystemTextAlignment(this Base.Enums.TextAlignment alignment)
        {
            switch (alignment)
            {
                case Base.Enums.TextAlignment.Left:
                    return System.Windows.TextAlignment.Left;
                case Base.Enums.TextAlignment.Right:
                    return System.Windows.TextAlignment.Right;
                case Base.Enums.TextAlignment.Center:
                    return System.Windows.TextAlignment.Center;
                default:
                    return System.Windows.TextAlignment.Left;
            }
        }
    }
}