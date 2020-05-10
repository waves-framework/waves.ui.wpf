using System;
using System.Windows;
using Fluid.UI.Windows.Controls.Drawing.Behavior;
using Fluid.UI.Windows.Controls.Drawing.ViewModel;
using Microsoft.Xaml.Behaviors;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.Behavior
{
    /// <summary>
    ///     Paint surface command behavior.
    /// </summary>
    public class SkiaPaintBehavior : PaintBehavior<SKElement>
    {
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