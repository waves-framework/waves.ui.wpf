using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Controls.Modality.ViewModel;

namespace Fluid.UI.Windows.Showcase.ViewModel.ModalWindow
{
    /// <summary>
    /// Show property modal window view model.
    /// </summary>
    public class ShowPropertyModalWindowViewModel : ModalWindowPresentationViewModel
    {
        /// <summary>
        /// Creates new instance of <see cref="ShowPropertyModalWindowViewModel"/>.
        /// </summary>
        public ShowPropertyModalWindowViewModel(IProperty property)
        {
            Property = property;
        }

        /// <summary>
        /// Gets  property.
        /// </summary>
        public IProperty Property { get; }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}