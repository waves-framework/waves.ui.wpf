using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;
using Fluid.Presentation.Base;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Modality.Presentation.Controllers.Interfaces;
using Fluid.UI.Windows.Controls.Modality.Presentation.Interfaces;

namespace Fluid.UI.Windows.Controls.Modality.Presentation.Controllers
{
    /// <summary>
    /// Modality windows presentation controller.
    /// </summary>
    public class ModalWindowsPresentationController : PresentationController, IModalWindowsPresentationController
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
        public void ShowWindow(IModalWindowPresentation presentation)
        {
            RegisterPresentation(presentation);

            presentation.WindowRequestClosing += OnPresentationWindowRequestClosing;

            SelectedPresentation = presentation;

            FadeInWindow(presentation);

            CheckVisibility();
        }

        /// <inheritdoc />
        public void HideWindow(IModalWindowPresentation presentation)
        {
            if (SelectedPresentation.Equals(presentation))
                SelectedPresentation = null;

            FadeOutWindow(presentation);

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
        private void OnPresentationWindowRequestClosing(object sender, IModalWindowPresentation e)
        {
            HideWindow(e);
        }

        /// <summary>
        /// Animates fade in.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        private void FadeInWindow(IPresentation presentation)
        {
            var view = presentation.View as UIElement;
            if (view == null) return;

            view.Opacity = 0;

            var animation = new DoubleAnimation() {From = 0, To = 1, Duration = new Duration(TimeSpan.FromMilliseconds(250))};
            view.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        /// <summary>
        /// Animates fade out.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        private void FadeOutWindow(IPresentation presentation)
        {
            var view = presentation.View as UIElement;
            if (view == null) return;

            view.Opacity = 0;

            var animation = new DoubleAnimation() { From = 1, To = 0, Duration = new Duration(TimeSpan.FromMilliseconds(250)) };
            view.BeginAnimation(UIElement.OpacityProperty, animation);
        }
    }
}