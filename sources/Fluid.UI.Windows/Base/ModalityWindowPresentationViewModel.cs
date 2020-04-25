using System.Collections.Generic;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Base.Interfaces;

namespace Fluid.UI.Windows.Base
{
    /// <summary>
    /// Base abstract modality window presentation view model.
    /// </summary>
    public abstract class ModalityWindowPresentationViewModel : PresentationViewModel, IModalityWindowPresentationViewModel
    {
        /// <inheritdoc />
        public ICollection<IModalityWindowAction> Actions { get; private set; }

        /// <inheritdoc />
        public void AttachActions(ICollection<IModalityWindowAction> actions)
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