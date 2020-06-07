using System.Windows;
using Waves.Presentation.Interfaces;

namespace Waves.UI.WPF.Showcase.Presentation.Tabs.Interfaces
{
    /// <summary>
    /// Interface for tab presentation.
    /// </summary>
    public interface ITabPresentation : IPresentation
    {
        /// <summary>
        /// Gets tab name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets vector icon path data.
        /// </summary>
        string VectorIconPathData { get; }

        /// <summary>
        /// Gets vector icon thickness.
        /// </summary>
        Thickness VectorIconThickness { get; }
    }
}