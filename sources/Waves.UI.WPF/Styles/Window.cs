using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Waves.UI.WPF.Extensions;

namespace Waves.UI.WPF.Styles
{
    /// <summary>
    ///     Window.
    /// </summary>
    public partial class Window
    {
        private bool _resizeInProgress;

        /// <summary>
        ///     Actions when window loaded.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            var window = sender as System.Windows.Window;
            if (window == null) return;

            window.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        /// <summary>
        ///     Actions when mouse down on title bar.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnTitleBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
                OnMaximizeButtonClick(sender, e);

            else if (e.LeftButton == MouseButtonState.Pressed) sender.ForWindowFromTemplate(w => w.DragMove());
        }

        /// <summary>
        ///     Actions when mouse moves on title bar.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnTitleBarMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                sender.ForWindowFromTemplate(w =>
                {
                    if (w.WindowState != WindowState.Maximized) return;

                    w.BeginInit();
                    const double adjustment = 40.0;
                    var mouse1 = e.MouseDevice.GetPosition(w);
                    var width1 = Math.Max(w.ActualWidth - 2 * adjustment, adjustment);
                    w.WindowState = WindowState.Normal;
                    var width2 = Math.Max(w.ActualWidth - 2 * adjustment, adjustment);
                    w.Left = (mouse1.X - adjustment) * (1 - width2 / width1);
                    w.Top = -7;
                    w.EndInit();
                    w.DragMove();
                });
        }

        /// <summary>
        ///     Actions when clicks on minimize window button.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => w.WindowState = WindowState.Minimized);
        }

        /// <summary>
        ///     Actions when clicks on maximize window button.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnMaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(
                w =>
                    w.WindowState =
                        w.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized);
        }

        /// <summary>
        ///     Actions when clicks on close window button.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            sender.ForWindowFromTemplate(w => w.Close());
        }

        /// <summary>
        ///     Actions when window resize initializes.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnWindowResizeInitialization(object sender, MouseButtonEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas == null) return;

            _resizeInProgress = true;

            canvas.CaptureMouse();
        }

        /// <summary>
        ///     Actions when windows is resizing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnWindowResizing(object sender, MouseEventArgs e)
        {
            if (!_resizeInProgress) return;

            var canvas = sender as Canvas;
            var window = sender.GetWindow();

            if (canvas == null) return;
            if (window == null) return;

            var width = e.GetPosition(sender.GetWindow()).X;
            var height = e.GetPosition(sender.GetWindow()).Y;

            canvas.CaptureMouse();

            var name = canvas.Name.ToLower();

            // top
            if (name.Contains("top"))
            {
                height -= 5;
                window.Top += height;
                height = window.Height - height;
                if (height > 0) window.Height = height;
            }

            // left
            if (name.Contains("left"))
            {
                width -= 5;
                window.Left += width;
                width = window.Width - width;
                if (width > 0) window.Width = width;
            }

            // right
            if (name.Contains("right"))
            {
                width += 5;
                if (width > 0)
                    window.Width = width;
            }

            // bottom
            if (name.Contains("bottom"))
            {
                height += 5;
                if (height > 0)
                    window.Height = height;
            }
        }

        /// <summary>
        ///     Actions when window resize ends.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnWindowResizeEnd(object sender, MouseButtonEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas == null) return;

            _resizeInProgress = false;

            canvas.ReleaseMouseCapture();
        }
    }
}