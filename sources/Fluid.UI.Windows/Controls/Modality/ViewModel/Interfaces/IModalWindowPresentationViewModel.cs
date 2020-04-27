using System.Collections.Generic;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Modality.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Modality.ViewModel.Interfaces
{
    /// <summary>
    ///     Interface for modality window presentation view model.
    /// </summary>
    public interface IModalWindowPresentationViewModel : IPresentationViewModel
    {
        /// <summary>
        /// Gets collections of actions.
        /// </summary>
        ICollection<IModalWindowAction> Actions { get; }

        /// <summary>
        /// Attaches actions.
        /// </summary>
        /// <param name="actions">Actions.</param>
        void AttachActions(ICollection<IModalWindowAction> actions);

        /// <summary>
        /// Clear actions.
        /// </summary>
        void ClearActions();
    }
}