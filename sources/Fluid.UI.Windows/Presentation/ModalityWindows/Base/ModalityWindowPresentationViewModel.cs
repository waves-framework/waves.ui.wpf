using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Presentation.ModalityWindows.Interfaces;

namespace Fluid.UI.Windows.Presentation.ModalityWindows.Base
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