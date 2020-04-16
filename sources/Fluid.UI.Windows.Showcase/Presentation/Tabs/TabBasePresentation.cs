using System.Windows;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Showcase.Presentation.Tabs.Interfaces;

namespace Fluid.UI.Windows.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Base tab presentation.
    /// </summary>
    public abstract class TabBasePresentation : Fluid.Presentation.Base.Presentation, ITabPresentation
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