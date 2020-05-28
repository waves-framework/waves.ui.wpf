using System;
using System.Windows;
using System.Windows.Input;
using Waves.Core.Base.Enums;
using Waves.Core.Base.EventArgs;
using Waves.Core.Services.Interfaces;
using Waves.UI.Windows.Controls.Drawing.ViewModel;
using Microsoft.Xaml.Behaviors;

namespace Waves.UI.Windows.Controls.Drawing.Behavior
{
    /// <summary>
    /// Paint behavior class.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class PaintBehavior<T>: Behavior<T>
        where T : FrameworkElement
    {
        /// <summary>
        /// Creates new instance of <see cref="PaintBehavior{T}"/>
        /// </summary>
        public PaintBehavior(IInputService inputService)
        {
            InputService = inputService;
        }

        /// <summary>
        /// Gets or sets data context.
        /// </summary>
        protected DrawingElementViewModel DataContext { get; set; }

        /// <summary>
        ///     Gets or sets input service.
        /// </summary>
        protected IInputService InputService { get; set; }

        /// <inheritdoc />
        protected override void OnAttached()
        {
            base.OnAttached();

            var element = AssociatedObject;

            element.DataContextChanged += OnDataContextChanged;
            element.SizeChanged += OnSizeChanged;
            element.MouseMove += OnMouseMove;
            element.MouseEnter += OnMouseEnter;
            element.MouseLeave += OnMouseLeave;
            element.MouseDown += OnMouseDown;
            element.MouseUp += OnMouseUp;
            element.MouseWheel += OnMouseWheel;
            element.TouchEnter += OnTouchEnter;

            // TODO: touch.
        }

        /// <inheritdoc />
        protected override void OnDetaching()
        {
            base.OnDetaching();

            var element = AssociatedObject;

            element.DataContextChanged -= OnDataContextChanged;
            element.SizeChanged -= OnSizeChanged;
            element.DataContextChanged -= OnDataContextChanged;
            element.SizeChanged -= OnSizeChanged;
            element.MouseMove -= OnMouseMove;
            element.MouseEnter -= OnMouseEnter;
            element.MouseLeave -= OnMouseLeave;
            element.MouseDown -= OnMouseDown;
            element.MouseUp -= OnMouseUp;
            element.MouseWheel -= OnMouseWheel;
            element.TouchEnter -= OnTouchEnter;

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

            // attaches input service.
            dataContext.InputService = InputService;

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

        /// <summary>
        /// Actions when mouse move.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                Waves.Core.Base.Enums.MouseButton.None,
                PointerEventType.Move,
                0,
                new Waves.Core.Base.Point(),
                new Waves.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse enters.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);
            var args = new PointerEventArgs(
                Waves.Core.Base.Enums.MouseButton.None,
                PointerEventType.Enter,
                0,
                new Waves.Core.Base.Point(),
                new Waves.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse leaves.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);
            var args = new PointerEventArgs(
                Waves.Core.Base.Enums.MouseButton.None,
                PointerEventType.Leave,
                0,
                new Waves.Core.Base.Point(),
                new Waves.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse button is down.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var button = Waves.Core.Base.Enums.MouseButton.None;

            switch (e.ChangedButton)
            {
                case System.Windows.Input.MouseButton.Left:
                    button = Waves.Core.Base.Enums.MouseButton.Left;
                    break;
                case System.Windows.Input.MouseButton.Middle:
                    button = Waves.Core.Base.Enums.MouseButton.Middle;
                    break;
                case System.Windows.Input.MouseButton.Right:
                    button = Waves.Core.Base.Enums.MouseButton.Right;
                    break;
            }

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                button,
                PointerEventType.Press,
                0,
                new Waves.Core.Base.Point(),
                new Waves.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse ups.
        /// TODO: combine methods.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var button = Waves.Core.Base.Enums.MouseButton.None;

            switch (e.ChangedButton)
            {
                case System.Windows.Input.MouseButton.Left:
                    button = Waves.Core.Base.Enums.MouseButton.Left;
                    break;
                case System.Windows.Input.MouseButton.Middle:
                    button = Waves.Core.Base.Enums.MouseButton.Middle;
                    break;
                case System.Windows.Input.MouseButton.Right:
                    button = Waves.Core.Base.Enums.MouseButton.Right;
                    break;
            }

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                button,
                PointerEventType.Release,
                0,
                new Waves.Core.Base.Point(),
                new Waves.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse scrolling.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                Waves.Core.Base.Enums.MouseButton.None,
                PointerEventType.VerticalScroll,
                0,
                new Waves.Core.Base.Point(e.Delta, 0),
                new Waves.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when touch enters.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnTouchEnter(object sender, TouchEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetTouchPoint(element).Position;

            var args = new PointerEventArgs(
                Waves.Core.Base.Enums.MouseButton.None,
                PointerEventType.Enter,
                0,
                new Waves.Core.Base.Point(),
                new Waves.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }
    }
}