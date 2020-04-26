using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Controls.Modality.Base.Interfaces;
using Fluid.UI.Windows.Controls.Modality.Presentation.Interfaces;

namespace Fluid.UI.Windows.Extensions
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
        public static IModalWindowPresentation AddAction(this IModalWindowPresentation presentation, IModalWindowAction action)
        {
            presentation.Actions.Add(action);

            return presentation;
        }
    }
}