using System.Windows;
using Waves.Presentation.Interfaces;
using Waves.UI.WPF.Showcase.View.Control.Tabs;
using Waves.UI.WPF.Showcase.ViewModel.Tabs;

namespace Waves.UI.WPF.Showcase.Presentation.Tabs
{
    /// <summary>
    /// ComboBoxes tab presentation.
    /// </summary>
    public class ComboBoxesTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Comboboxes";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M2 6C0.895 6 0 6.895 0 8L0 16C0 17.105 0.895 18 2 18L14 18L14 6L2 6 z M 16 6L16 18L22 18C23.105 18 24 17.105 24 16L24 8C24 6.895 23.105 6 22 6L16 6 z M 17.5 11L22.5 11L20 13.5L17.5 11 z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, -4, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ComboBoxesTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new ComboBoxesTabViewModel();
    }
}