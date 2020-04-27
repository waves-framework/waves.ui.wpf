using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Modality.Presentation.Interfaces;

namespace Fluid.UI.Windows.Controls.Modality.Presentation.Controllers.Interfaces
{
    /// <summary>
    /// Interface for modality windows presentation controller.
    /// </summary>
    public interface IModalWindowsPresentationController : IPresentationController
    {
        /// <summary>
        /// Gets whether modality controller visible.
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Shows window.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        void ShowWindow(IModalWindowPresentation presentation);

        /// <summary>
        /// Hides window.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        void HideWindow(IModalWindowPresentation presentation);
    }
}