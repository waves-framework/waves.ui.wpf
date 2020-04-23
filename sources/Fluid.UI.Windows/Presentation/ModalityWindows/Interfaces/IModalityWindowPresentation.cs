using System;
using System.Collections.Generic;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base.Interfaces;

namespace Fluid.UI.Windows.Presentation.ModalityWindows.Interfaces
{
    /// <summary>
    /// Interface for modality window presentation.
    /// </summary>
    public interface IModalityWindowPresentation : IPresentation
    {
        /// <summary>
        /// Gets icon.
        /// </summary>
        IVectorIcon Icon { get; }

        /// <summary>
        /// Gets title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets or sets height of window.
        /// </summary>
        double MaxHeight { get; set; }

        /// <summary>
        /// Gets or sets width of window.
        /// </summary>
        double MaxWidth { get; set; }

        /// <summary>
        ///     Gets collection of actions.
        /// </summary>
        ICollection<IModalityWindowAction> Actions { get; }

        /// <summary>
        /// Event for closing request handling.
        /// </summary>
        event EventHandler<IModalityWindowPresentation> WindowRequestClosing;
    }
}