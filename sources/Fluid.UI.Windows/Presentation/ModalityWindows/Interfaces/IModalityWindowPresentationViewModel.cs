using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base.Interfaces;

namespace Fluid.UI.Windows.Presentation.ModalityWindows.Interfaces
{
    /// <summary>
    ///     Interface for modality window presentation view model.
    /// </summary>
    public interface IModalityWindowPresentationViewModel : IPresentationViewModel
    {
        /// <summary>
        /// Gets collections of actions.
        /// </summary>
        ICollection<IModalityWindowAction> Actions { get; }

        /// <summary>
        /// Attaches actions.
        /// </summary>
        /// <param name="actions">Actions.</param>
        void AttachActions(ICollection<IModalityWindowAction> actions);

        /// <summary>
        /// Clear actions.
        /// </summary>
        void ClearActions();
    }
}