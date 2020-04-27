using System;
using Fluid.UI.Windows.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Modality.Base.Interfaces
{
    /// <summary>
    /// Interface for modality window action.
    /// </summary>
    public interface IModalWindowAction
    {
        /// <summary>
        /// Gets whether modality window action is accent.
        /// </summary>
        bool IsAccent { get; }

        /// <summary>
        /// Gets or sets whether action is enabled.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// Gets icon.
        /// </summary>
        IVectorIcon Icon { get; }

        /// <summary>
        /// Gets caption.
        /// </summary>
        string Caption { get; }

        /// <summary>
        /// Gets tooltip info.
        /// </summary>
        string ToolTip { get; }

        /// <summary>
        /// Action.
        /// </summary>
        Action Action { get; }
    }
}