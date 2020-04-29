using System;
using System.Windows;
using System.Windows.Input;
using Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.ViewModel;
using Microsoft.Xaml.Behaviors;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;

namespace Fluid.UI.Windows.Controls.Drawing.Behaviors
{
    /// <summary>
    ///     Paint surface command behavior.
    /// </summary>
    public class PaintSurfaceCommandBehavior : Behavior<SKElement>
    {
        private CanvasViewModel _dataContext;

        /// <summary>
        ///     Gets or sets paint command property.
        /// </summary>
        public static readonly DependencyProperty PaintCommandProperty =
            DependencyProperty.RegisterAttached(
                nameof(PaintCommand),
                typeof(ICommand),
                typeof(PaintSurfaceCommandBehavior),
                null);

        /// <summary>
        ///     Gets command.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Command.</returns>
        public static ICommand GetValue(DependencyObject obj)
        {
            return (ICommand) obj.GetValue(PaintCommandProperty);
        }

        /// <summary>
        ///     Sets command.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Command.</param>
        public static void SetValue(DependencyObject obj, ICommand value)
        {
            obj.SetValue(PaintCommandProperty, value);
        }

        /// <summary>
        ///     Gets or sets paint command.
        /// </summary>
        public ICommand PaintCommand
        {
            get => (ICommand) GetValue(PaintCommandProperty);
            set => SetValue(PaintCommandProperty, value);
        }

        /// <inheritdoc />
        protected override void OnAttached()
        {
            base.OnAttached();

            var skElement = AssociatedObject;

            skElement.DataContextChanged += OnDataContextChanged;
            skElement.SizeChanged += OnSizeChanged;
            skElement.PaintSurface += OnPaintSurface;
        }

        /// <inheritdoc />
        protected override void OnDetaching()
        {
            base.OnDetaching();

            var skElement = AssociatedObject;

            skElement.DataContextChanged -= OnDataContextChanged;
            skElement.SizeChanged -= OnSizeChanged;
            skElement.PaintSurface -= OnPaintSurface;

            if (_dataContext != null)
                _dataContext.RedrawRequested -= OnRedrawRequested;
        }

        /// <summary>
        ///     Actions when size changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element == null) return;

            AssociatedObject.InvalidateMeasure();
            AssociatedObject.InvalidateArrange();

            if (_dataContext == null) return;

            var size = e.NewSize;

            _dataContext.Width = Convert.ToSingle(size.Width);
            _dataContext.Height = Convert.ToSingle(size.Height);

            if (Math.Abs(size.Width) < double.Epsilon || Math.Abs(size.Height) < double.Epsilon)
            {
                _dataContext.IsDrawingInitialized = false;
            }
            else
            {
                _dataContext.IsDrawingInitialized = true;
            }
        }

        /// <summary>
        ///     Actions when data context changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element == null) return;

            var dataContext = element.DataContext as CanvasViewModel;
            if (dataContext == null) return;

            _dataContext = dataContext;

            _dataContext.RedrawRequested += OnRedrawRequested;
        }

        /// <summary>
        /// Notifies when redraw requested.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments/</param>
        private void OnRedrawRequested(object sender, EventArgs e)
        {
            Dispatcher?.Invoke(delegate
            {
                try
                {
                    AssociatedObject.InvalidateVisual();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            });
        }

        /// <summary>
        ///     Actions when paint requested.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            if (_dataContext == null) return;

            if (_dataContext.Canvas == null)
                _dataContext.Canvas = e.Surface.Canvas;

            _dataContext.Draw();
        }
    }
}