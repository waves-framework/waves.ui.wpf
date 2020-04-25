using System.Collections.Generic;
using Fluid.Presentation.Interfaces;

namespace Fluid.UI.Windows.Base.Interfaces
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