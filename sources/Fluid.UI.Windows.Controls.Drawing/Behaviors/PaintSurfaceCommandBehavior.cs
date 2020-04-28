using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;

namespace Fluid.UI.Windows.Controls.Drawing.Behaviors
{
    /// <summary>
    /// Paint surface command behavior.
    /// </summary>
    public class PaintSurfaceCommandBehavior : Behavior<SKElement>
    {
        private object _dataContext;

        /// <summary>
        /// Gets or sets paint command property.
        /// </summary>
        public static readonly DependencyProperty PaintCommandProperty =
            DependencyProperty.RegisterAttached(
                nameof(PaintCommand),
                typeof(ICommand),
                typeof(PaintSurfaceCommandBehavior),
                null);

        /// <summary>
        /// Gets command.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Command.</returns>
        public static ICommand GetValue(DependencyObject obj)
        {
            return (ICommand) obj.GetValue(PaintCommandProperty);
        }

        /// <summary>
        /// Sets command.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Command.</param>
        public static void SetValue(DependencyObject obj, ICommand value)
        {
            obj.SetValue(PaintCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets paint command.
        /// </summary>
        public ICommand PaintCommand
        {
            get => (ICommand)GetValue(PaintCommandProperty);
            set => SetValue(PaintCommandProperty, value);
        }

        /// <inheritdoc />
        protected override void OnAttached()
        {
            base.OnAttached();

            var skElement = AssociatedObject;

            skElement.DataContextChanged += OnDataContextChanged;
            skElement.PaintSurface += OnPaintSurface;
        }

        /// <inheritdoc />
        protected override void OnDetaching()
        {
            base.OnDetaching();

            var skElement = AssociatedObject;

            skElement.DataContextChanged -= OnDataContextChanged;
            skElement.PaintSurface -= OnPaintSurface;
        }

        /// <summary>
        /// Actions when data context changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element == null) return;

            _dataContext = element.DataContext;
        }

        /// <summary>
        /// Actions when paint requested.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            if (PaintCommand?.CanExecute(e) == true)
            {
                PaintCommand.Execute(e);
            }
        }
    }
}