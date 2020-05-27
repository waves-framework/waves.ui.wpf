using System.Windows;
using Waves.Presentation.Interfaces;
using Waves.UI.Windows.Showcase.View.Control.Tabs;
using Waves.UI.Windows.Showcase.ViewModel.Tabs;

namespace Waves.UI.Windows.Showcase.Presentation.Tabs
{
    /// <summary>
    /// ListBoxes tab presentation.
    /// </summary>
    public class ListBoxesTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "ListBoxes";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M5 2C3.895 2 3 2.895 3 4L3 6C3 7.105 3.895 8 5 8L7 8C8.105 8 9 7.105 9 6L9 4C9 2.895 8.105 2 7 2L5 2 z M 11 4L11 6L21 6L21 4L11 4 z M 5 9C3.895 9 3 9.895 3 11L3 13C3 14.105 3.895 15 5 15L7 15C8.105 15 9 14.105 9 13L9 11C9 9.895 8.105 9 7 9L5 9 z M 11 11L11 13L21 13L21 11L11 11 z M 5 16C3.9069372 16 3 16.906937 3 18L3 20C3 21.093063 3.9069372 22 5 22L7 22C8.0930628 22 9 21.093063 9 20L9 18C9 16.906937 8.0930628 16 7 16L5 16 z M 5 18L7 18L7 20L5 20L5 18 z M 11 18L11 20L21 20L21 18L11 18 z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, 0, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ListBoxesTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new ListBoxesTabViewModel();
    }
}