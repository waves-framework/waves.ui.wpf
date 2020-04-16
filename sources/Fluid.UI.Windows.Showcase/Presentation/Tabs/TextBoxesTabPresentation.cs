using System.Windows;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Showcase.View.Control.Tabs;
using Fluid.UI.Windows.Showcase.ViewModel.Tabs;

namespace Fluid.UI.Windows.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Textboxes tab presentation.
    /// </summary>
    public class TextBoxesTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Textboxes";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12 3L12 5C12.833333 5 13.421991 5.2041597 13.802734 5.3945312C13.899195 5.4427618 13.93573 5.4711718 14 5.5097656L14 18.490234C13.93573 18.528828 13.899195 18.557238 13.802734 18.605469C13.421991 18.79584 12.833333 19 12 19L12 21C13.166667 21 14.078009 20.70416 14.697266 20.394531C14.883184 20.301572 14.85968 20.280666 15 20.1875C15.14032 20.28067 15.116816 20.301572 15.302734 20.394531C15.921991 20.70416 16.833333 21 18 21L18 19C17.166667 19 16.578009 18.79584 16.197266 18.605469C16.100805 18.557238 16.06427 18.528828 16 18.490234L16 5.5097656C16.06427 5.4711718 16.100805 5.4427618 16.197266 5.3945312C16.578009 5.2041597 17.166667 5 18 5L18 3C16.833333 3 15.921991 3.2958402 15.302734 3.6054688C15.116816 3.6984278 15.14032 3.7193337 15 3.8125C14.85968 3.7193337 14.883184 3.6984278 14.697266 3.6054688C14.078009 3.2958402 13.166667 3 12 3 z M 4 8C2.9069372 8 2 8.9069372 2 10L2 14C2 15.093063 2.9069372 16 4 16L12 16L12 14L4 14L4 10L12 10L12 8L4 8 z M 18 8L18 10L20 10L20 14L18 14L18 16L20 16C21.093063 16 22 15.093063 22 14L22 10C22 8.9069372 21.093063 8 20 8L18 8 z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, -2, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new TextBoxesTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new TextBoxesTabViewModel();
    }
}