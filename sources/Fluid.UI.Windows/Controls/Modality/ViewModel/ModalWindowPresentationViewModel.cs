using System.Collections.Generic;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Modality.Base.Interfaces;
using Fluid.UI.Windows.Controls.Modality.ViewModel.Interfaces;

namespace Fluid.UI.Windows.Controls.Modality.ViewModel
{
    /// <summary>
    /// Base abstract modality window presentation view model.
    /// </summary>
    public abstract class ModalWindowPresentationViewModel : PresentationViewModel, IModalWindowPresentationViewModel
    {
        /// <inheritdoc />
        public ICollection<IModalWindowAction> Actions { get; private set; }

        /// <inheritdoc />
        public void AttachActions(ICollection<IModalWindowAction> actions)
        {
            Actions = actions;
        }

        /// <inheritdoc />
        public void ClearActions()
        {
            Actions.Clear();
        }
    }
}