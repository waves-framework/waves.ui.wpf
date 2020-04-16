using System.Windows;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Showcase.View.Control.Tabs;
using Fluid.UI.Windows.Showcase.ViewModel.Tabs;

namespace Fluid.UI.Windows.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Text tab presentation.
    /// </summary>
    public class TextTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Text styles";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M4 3L4 7L6 7L6 5L11 5L11 19L9 19L9 21L15 21L15 19L13 19L13 5L18 5L18 7L20 7L20 3L4 3 z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0,-2,0,0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new TextTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new TextTabViewModel();
    }
}