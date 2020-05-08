namespace Fluid.UI.Windows.Controls.Drawing.Base.Interfaces
{
    /// <summary>
    /// Interface of text paint instances.
    /// </summary>
    public interface ITextPaint : IPaint
    {
        /// <summary>
        /// Gets or sets text style.
        /// </summary>
        ITextStyle TextStyle { get; set; }
    }
}