using System;
using System.Windows;
using System.Windows.Controls;
using Waves.Core.Services.Interfaces;
using Waves.UI.WPF.Controls.Drawing.Behavior;
using Waves.UI.WPF.Helpers;

namespace Waves.UI.WPF.Controls.Drawing.Engines.System.Behavior
{
    /// <summary>
    ///     Paint surface command behavior.
    /// </summary>
    public class SystemPaintBehavior : PaintBehavior<Canvas>
    {
        /// <inheritdoc />
        public SystemPaintBehavior(IInputService inputService) : base(inputService)
        {
        }

        /// <summary>
        ///     Actions when size changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected override void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            base.OnSizeChanged(sender, e);

            DataContext?.Draw(AssociatedObject);
        }

        /// <summary>
        ///     Actions when data context changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected override void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            base.OnDataContextChanged(sender, e);

            DataContext?.Draw(AssociatedObject);
        }

        /// <summary>
        /// Notifies when redraw requested.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments/</param>
        protected override void OnRedrawRequested(object sender, EventArgs e)
        {
            base.OnRedrawRequested(sender, e);

            DispatcherHelper.Invoke(() =>
            {
                DataContext?.Draw(AssociatedObject);
            });
        }
    }
}