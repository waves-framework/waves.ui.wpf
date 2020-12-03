using System;
using System.Windows;
using System.Windows.Media.Animation;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.UI.WPF.Controls.Modality.Presentation.Controllers
{
    /// <summary>
    ///     Modality windows presentation controller.
    /// </summary>
    public class ModalWindowsPresentationController : UI.Modality.Presentation.Controllers.ModalWindowPresenterController
    {
        /// <inheritdoc />
        public ModalWindowsPresentationController(IWavesCore core) : base(core)
        {
        }
        
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Modal windows presentation controller";
        
        /// <summary>
        ///     Animates fade in.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        protected override void FadeInWindow(IPresenter presentation)
        {
            var view = presentation.View as UIElement;
            if (view == null) return;

            view.Opacity = 0;

            var animation = new DoubleAnimation
                {From = 0, To = 1, Duration = new Duration(TimeSpan.FromMilliseconds(250))};
            view.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        /// <summary>
        ///     Animates fade out.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        protected override void FadeOutWindow(IPresenter presentation)
        {
            var view = presentation.View as UIElement;
            if (view == null) return;

            view.Opacity = 0;

            var animation = new DoubleAnimation
                {From = 1, To = 0, Duration = new Duration(TimeSpan.FromMilliseconds(250))};
            view.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }


    }
}