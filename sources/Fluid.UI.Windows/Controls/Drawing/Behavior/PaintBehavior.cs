using System;
using System.Windows;
using Fluid.UI.Windows.Controls.Drawing.ViewModel;
using Microsoft.Xaml.Behaviors;

namespace Fluid.UI.Windows.Controls.Drawing.Behavior
{
    /// <summary>
    /// Paint behavior class.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class PaintBehavior<T>: Behavior<T>
        where T : FrameworkElement
    {
        /// <summary>
        /// Gets or sets data context.
        /// </summary>
        protected DrawingElementViewModel DataContext { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="PaintBehavior{T}"/>
        /// </summary>
        public PaintBehavior()
        {
        }

        /// <inheritdoc />
        protected override void OnAttached()
        {
            base.OnAttached();

            var element = AssociatedObject;

            element.DataContextChanged += OnDataContextChanged;
            element.SizeChanged += OnSizeChanged;
        }

        /// <inheritdoc />
        protected override void OnDetaching()
        {
            base.OnDetaching();

            var skElement = AssociatedObject;

            skElement.DataContextChanged -= OnDataContextChanged;
            skElement.SizeChanged -= OnSizeChanged;

            if (DataContext != null)
                DataContext.RedrawRequested -= OnRedrawRequested;
        }

        /// <summary>
        ///     Actions when size changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected virtual void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!(sender is FrameworkElement element)) return;

            AssociatedObject.InvalidateMeasure();
            AssociatedObject.InvalidateArrange();

            if (DataContext == null) return;

            var size = e.NewSize;

            DataContext.Width = Convert.ToSingle(size.Width);
            DataContext.Height = Convert.ToSingle(size.Height);

            if (Math.Abs(size.Width) < double.Epsilon || Math.Abs(size.Height) < double.Epsilon)
            {
                DataContext.IsDrawingInitialized = false;
            }
            else
            {
                DataContext.IsDrawingInitialized = true;
            }

            AssociatedObject.InvalidateVisual();
        }

        /// <summary>
        ///     Actions when data context changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected virtual void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is FrameworkElement element)) return;
            if (!(element.DataContext is DrawingElementViewModel dataContext)) return;

            if (e.OldValue != null)
            {
                if (e.OldValue is DrawingElementViewModel oldContext)
                {
                    oldContext.RedrawRequested -= OnRedrawRequested;
                }
            }

            DataContext = dataContext;

            DataContext.RedrawRequested += OnRedrawRequested;
        }

        /// <summary>
        /// Notifies when redraw requested.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments/</param>
        protected virtual void OnRedrawRequested(object sender, EventArgs e)
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
    }
}