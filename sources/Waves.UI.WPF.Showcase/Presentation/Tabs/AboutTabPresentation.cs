using System.Windows;
using Waves.Presentation.Interfaces;
using Waves.UI.WPF.Showcase.View.Control.Tabs;
using Waves.UI.WPF.Showcase.ViewModel.Tabs;

namespace Waves.UI.WPF.Showcase.Presentation.Tabs
{
    /// <summary>
    /// About tab presentation.
    /// </summary>
    public class AboutTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "About";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12,0.143c0,0-8,8.486-8,13.857c0,4.457,3.543,8,8,8s8-3.543,8-8C20,8.629,12,0.143,12,0.143z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, 0, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new AboutTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new AboutTabViewModel();
    }
}