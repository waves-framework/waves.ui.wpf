using System.Linq;
using Fluid.Presentation.Base;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base.Interfaces;

namespace Fluid.UI.Windows.Base
{
    /// <summary>
    /// Modality windows presentation controller.
    /// </summary>
    public class ModalityWindowsPresentationController : PresentationController, IModalityWindowsPresentationController
    {
        private IPresentation _presentation;

        /// <inheritdoc />
        public bool IsVisible { get; private set; }

        /// <inheritdoc />
        public override IPresentation SelectedPresentation
        {
            get => _presentation;
            set
            {
                if (Equals(value, _presentation)) return;

                if (_presentation != null)
                {
                    Presentations.Add(_presentation);
                }

                _presentation = value;

                if (_presentation != null)
                {
                    Presentations.Remove(_presentation);
                }

                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            CheckVisibility();
        }

        /// <inheritdoc />
        public void ShowWindow(IModalityWindowPresentation presentation)
        {
            RegisterPresentation(presentation);

            presentation.WindowRequestClosing += OnPresentationWindowRequestClosing;

            SelectedPresentation = presentation;

            CheckVisibility();
        }

        /// <inheritdoc />
        public void HideWindow(IModalityWindowPresentation presentation)
        {
            if (SelectedPresentation.Equals(presentation))
                SelectedPresentation = null;

            UnregisterPresentation(presentation);

            if (Presentations.Count > 0)
                SelectedPresentation = Presentations.Last();

            CheckVisibility();
        }

        /// <summary>
        /// Checks controllers visibility.
        /// </summary>
        private void CheckVisibility()
        {
            IsVisible = SelectedPresentation != null;
        }

        /// <summary>
        /// Notifies when window request closing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Window presentation.</param>
        private void OnPresentationWindowRequestClosing(object sender, IModalityWindowPresentation e)
        {
            HideWindow(e);
        }
    }
}