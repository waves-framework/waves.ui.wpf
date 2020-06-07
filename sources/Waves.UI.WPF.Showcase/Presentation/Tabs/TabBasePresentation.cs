using System.Windows;
using Waves.Presentation.Interfaces;
using Waves.UI.WPF.Showcase.Presentation.Tabs.Interfaces;

namespace Waves.UI.WPF.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Base tab presentation.
    /// </summary>
    public abstract class TabBasePresentation : Waves.Presentation.Base.Presentation, ITabPresentation
    {
        /// <inheritdoc />
        public abstract override IPresentationViewModel DataContext { get; }

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public abstract string VectorIconPathData { get; }

        /// <inheritdoc />
        public abstract Thickness VectorIconThickness { get; }
    }
}