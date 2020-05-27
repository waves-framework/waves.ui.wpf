using System.Windows;
using System.Windows.Media;

namespace Waves.UI.Windows.Base.Interfaces
{
    /// <summary>
    /// Interface for vector icon.
    /// </summary>
    public interface IVectorIcon
    {
        /// <summary>
        /// Gets name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets geometry of path data.
        /// </summary>
        Geometry PathData { get; }

        /// <summary>
        /// Gets width of icon.
        /// </summary>
        double Width { get; }

        /// <summary>
        /// Gets height of icon.
        /// </summary>
        double Height { get; }

        /// <summary>
        /// Gets icon padding.
        /// </summary>
        /// <remarks>
        /// Not all vector images are centered.
        /// In this regard, this parameter is required.
        /// </remarks>
        Thickness Padding { get; }
    }
}