using System;
using System.Runtime.InteropServices;
using System.Windows;
using Fluid.UI.Windows.Drawing.Engine.Skia.ViewModel;
using Microsoft.Xaml.Behaviors;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.Behavior
{
    /// <summary>
    ///     Paint surface command behavior.
    /// </summary>
    public class PaintBehavior : Behavior<SKElement>
    {
        private SkiaDrawingElementViewModel _dataContext;

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
            if (!(sender is FrameworkElement element)) return;

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

            var skElement = AssociatedObject;
            skElement.InvalidateVisual();
        }

        /// <summary>
        ///     Actions when data context changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is FrameworkElement element)) return;
            if (!(element.DataContext is SkiaDrawingElementViewModel dataContext)) return;

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
            _dataContext?.Draw(e.Surface);
        }
    }
}