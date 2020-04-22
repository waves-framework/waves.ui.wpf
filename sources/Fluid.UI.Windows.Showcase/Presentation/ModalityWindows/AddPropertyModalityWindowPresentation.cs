using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Presentation.ModalityWindows.Base;
using Fluid.UI.Windows.Showcase.View.ModalityWindow;
using Fluid.UI.Windows.Showcase.ViewModel.ModalityWindows;

namespace Fluid.UI.Windows.Showcase.Presentation.ModalityWindows
{
    /// <summary>
    /// Add property modality window presentation.
    /// </summary>
    public class AddPropertyModalityWindowPresentation : ModalityWindowPresentation
    {
        /// <inheritdoc />
        public override IVectorIcon Icon { get; }

        /// <inheritdoc />
        public override string Title => "Add property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new AddPropertyModalityWindowViewModel();

        /// <inheritdoc />
        public override IPresentationView View { get; } = new AddPropertyModalityWindowContentView();
    }
}