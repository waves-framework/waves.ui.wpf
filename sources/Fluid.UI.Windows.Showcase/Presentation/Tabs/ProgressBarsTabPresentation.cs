using System.Windows;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Showcase.View.Control.Tabs;
using Fluid.UI.Windows.Showcase.ViewModel.Tabs;

namespace Fluid.UI.Windows.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Progress bars tab presentation.
    /// </summary>
    public class ProgressBarsTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Progress";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M3.2128906 6C2.0035871 6 1 7.0035871 1 8.2128906L1 15.787109C1 16.996413 2.0035871 18 3.2128906 18L20.787109 18C21.996413 18 23 16.998173 23 15.789062L23 8.2128906C23 7.0035871 21.998172 6 20.789062 6L3.2128906 6 z M 15 8L20.789062 8C20.917953 8 21 8.0821941 21 8.2128906L21 15.789062C21 15.917954 20.917806 16 20.787109 16L15 16L15 8 z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, -2, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ProgressBarsTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new ProgressBarsTabViewModel();
    }
}