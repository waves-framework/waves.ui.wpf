using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.WPF.Controls.Drawing.Behavior;

namespace Waves.UI.WPF.Drawing.Engine.Skia.Behavior
{
    /// <summary>
    ///     Paint surface command behavior.
    /// </summary>
    public class SkiaPaintBehavior : PaintBehavior<SKElement>
    {
        /// <inheritdoc />
        public SkiaPaintBehavior(IInputService inputService) : base(inputService)
        {
        }

        /// <inheritdoc />
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PaintSurface += OnPaintSurface;
        }

        /// <inheritdoc />
        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PaintSurface -= OnPaintSurface;
        }

        /// <summary>
        ///     Actions when paint requested.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            DataContext?.Draw(e.Surface);
        }
    }
}