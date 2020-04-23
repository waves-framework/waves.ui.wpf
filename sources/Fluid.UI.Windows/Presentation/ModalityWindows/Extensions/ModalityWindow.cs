﻿using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Presentation.ModalityWindows.Interfaces;

namespace Fluid.UI.Windows.Presentation.ModalityWindows.Extensions
{
    /// <summary>
    /// Modality windows actions extensions.
    /// </summary>
    public static class ModalityWindow
    {
        /// <summary>
        /// Adds action to presentation.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        /// <param name="action">Action.</param>
        /// <returns>Presentation.</returns>
        public static IModalityWindowPresentation AddAction(this IModalityWindowPresentation presentation, IModalityWindowAction action)
        {
            presentation.Actions.Add(action);

            return presentation;
        }
    }
}