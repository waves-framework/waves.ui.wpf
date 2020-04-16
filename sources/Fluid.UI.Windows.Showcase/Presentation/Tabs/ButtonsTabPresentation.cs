using System.Windows;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Showcase.View.Control.Tabs;
using Fluid.UI.Windows.Showcase.ViewModel.Tabs;

namespace Fluid.UI.Windows.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Buttons tab presentation.
    /// </summary>
    public class ButtonsTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Buttons";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M22,7H2C0.895,7,0,7.895,0,9v6c0,1.105,0.895,2,2,2h20c1.105,0,2-0.895,2-2V9C24,7.895,23.105,7,22,7z M13,13h-2v-2h2V13z M17,13h-2v-2h2V13z M9,13H7v-2h2V13z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, -2, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ButtonsTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new ButtonsTabViewModel();
    }
}