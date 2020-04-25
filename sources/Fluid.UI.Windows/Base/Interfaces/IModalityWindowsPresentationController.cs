using Fluid.Presentation.Interfaces;

namespace Fluid.UI.Windows.Base.Interfaces
{
    /// <summary>
    /// Interface for modality windows presentation controller.
    /// </summary>
    public interface IModalityWindowsPresentationController : IPresentationController
    {
        /// <summary>
        /// Gets whether modality controller visible.
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// Shows window.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        void ShowWindow(IModalityWindowPresentation presentation);

        /// <summary>
        /// Hides window.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        void HideWindow(IModalityWindowPresentation presentation);
    }
}